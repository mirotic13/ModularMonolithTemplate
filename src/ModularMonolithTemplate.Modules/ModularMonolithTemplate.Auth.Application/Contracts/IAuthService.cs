using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;

namespace ModularMonolithTemplate.Auth.Application.Contracts;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
    Task LogoutAsync();
    Task<bool> RegisterAsync(string email, string fullName, string password);
}
