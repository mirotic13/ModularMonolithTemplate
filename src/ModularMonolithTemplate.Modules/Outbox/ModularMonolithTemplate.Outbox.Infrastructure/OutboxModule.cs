using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Outbox.Application;

namespace ModularMonolithTemplate.Outbox.Infrastructure;

public static class OutboxModule
{
    public static IServiceCollection AddOutbox<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddScoped<IEventPublisher, EventPublisherService<TDbContext>>();
        services.AddHostedService<OutboxCleanupService<TDbContext>>();
        services.AddHostedService<OutboxFailureAlertService<TDbContext>>();
        services.AddHostedService<OutboxProcessor<TDbContext>>();
        return services;
    }
}
