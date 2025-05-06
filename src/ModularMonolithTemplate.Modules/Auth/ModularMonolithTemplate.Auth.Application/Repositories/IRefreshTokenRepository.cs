using ModularMonolithTemplate.Auth.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Application.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetValidRefreshTokenAsync(string token, CancellationToken ct);
    Task<ApplicationUser?> GetUserByIdAsync(Guid userId, CancellationToken ct);
    Task<List<string>> GetUserRolesAsync(Guid userId, CancellationToken ct);
    Task RevokeAsync(RefreshToken token, CancellationToken ct);
    Task AddAsync(RefreshToken token, CancellationToken ct);
}
