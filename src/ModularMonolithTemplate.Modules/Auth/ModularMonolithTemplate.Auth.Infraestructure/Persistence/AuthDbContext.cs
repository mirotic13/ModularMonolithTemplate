using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Infraestructure.Persistence.Configurations;
using ModularMonolithTemplate.SharedKernel.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Infraestructure.Persistence;

public class AuthDbContext(DbContextOptions<AuthDbContext> options, IDomainEventDispatcher domainEventDispatcher) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    private readonly IDomainEventDispatcher _domainEventDispatcher = domainEventDispatcher;

    public DbSet<RevokedToken> RevokedTokens => Set<RevokedToken>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("auth");
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new ApplicationRoleConfiguration());
        builder.ApplyConfiguration(new RevokedTokenConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Count != 0)
            .SelectMany(e =>
            {
                var events = e.Entity.DomainEvents.ToList();
                e.Entity.ClearDomainEvents();
                return events;
            })
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        if (domainEvents.Count != 0)
        {
            await _domainEventDispatcher.DispatchEventsAsync(domainEvents, cancellationToken);
        }

        return result;
    }
}
