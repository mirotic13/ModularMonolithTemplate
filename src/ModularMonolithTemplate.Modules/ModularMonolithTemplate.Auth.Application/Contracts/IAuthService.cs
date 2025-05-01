namespace ModularMonolithTemplate.Auth.Application.Contracts;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
    Task LogoutAsync();
    Task<bool> RegisterAsync(string email, string fullName, string password);
}
