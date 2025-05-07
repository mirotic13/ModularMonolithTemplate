using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Domain.Repositories;
using ModularMonolithTemplate.Auth.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Auth.Infraestructure.Repositories;

public class RefreshTokenRepository(AuthDbContext context) : IRefreshTokenRepository
{
    private readonly AuthDbContext _context = context;

    public async Task<RefreshToken?> GetValidRefreshTokenAsync(string token, CancellationToken ct)
    {
        return await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == token && !t.Revoked && t.ExpiresAt > DateTime.UtcNow, ct);
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(Guid userId, CancellationToken ct)
    {
        return await _context.Users.FindAsync(new object[] { userId }, ct);
    }

    public async Task<List<string>> GetUserRolesAsync(Guid userId, CancellationToken ct)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name!)
            .ToListAsync(ct);
    }

    public async Task RevokeAsync(RefreshToken token, CancellationToken ct)
    {
        token.Revoke();
        await _context.SaveChangesAsync(ct);
    }

    public async Task AddAsync(RefreshToken token, CancellationToken ct)
    {
        _context.RefreshTokens.Add(token);
        await _context.SaveChangesAsync(ct);
    }
}
