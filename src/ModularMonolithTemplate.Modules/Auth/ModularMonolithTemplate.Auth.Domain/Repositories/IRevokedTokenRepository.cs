namespace 
    ModularMonolithTemplate.Auth.Application.Repositories;

public interface IRevokedTokenRepository
{
    Task<bool> IsTokenRevokedAsync(string jti);
    Task RevokeTokenAsync(string jti, Guid userId, DateTime? expiresAt);
}