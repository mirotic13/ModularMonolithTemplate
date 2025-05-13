namespace
    ModularMonolithTemplate.Auth.Domain.Repositories;

public interface IRevokedTokenRepository
{
    Task<bool> IsTokenRevokedAsync(string jti);
    Task RevokeTokenAsync(string jti, Guid userId, DateTime? expiresAt);
}