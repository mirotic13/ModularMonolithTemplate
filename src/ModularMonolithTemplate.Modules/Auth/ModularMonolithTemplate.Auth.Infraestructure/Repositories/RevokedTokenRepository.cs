using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Domain.Repositories;
using ModularMonolithTemplate.Auth.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Auth.Infraestructure.Repositories;

public class RevokedTokenRepository(AuthDbContext context) : IRevokedTokenRepository
{
    private readonly AuthDbContext _context = context;

    public async Task<bool> IsTokenRevokedAsync(string jti)
    {
        return await _context.RevokedTokens.AnyAsync(r => r.Jti == jti);
    }

    public async Task RevokeTokenAsync(string jti, Guid userId, DateTime? expiresAt)
    {
        var token = new RevokedToken(jti, userId, expiresAt);
        _context.RevokedTokens.Add(token);
        await _context.SaveChangesAsync();
    }
}

