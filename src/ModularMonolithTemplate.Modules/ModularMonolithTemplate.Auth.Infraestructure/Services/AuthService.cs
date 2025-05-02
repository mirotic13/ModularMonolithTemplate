using Microsoft.AspNetCore.Identity;
using ModularMonolithTemplate.Auth.Application.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using ModularMonolithTemplate.Auth.Infraestructure.Identity;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;

namespace ModularMonolithTemplate.Auth.Infraestructure.Services;

public class AuthService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly UserManager<AppUser> _userManager = userManager;

    public async Task<LoginResponse> LoginAsync(string email, string password)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, email),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Role, "Demo User")
        };

        var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContextAccessor.HttpContext!.SignInAsync(
        IdentityConstants.ApplicationScheme,
        principal,
        new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
        });

        return new LoginResponse
        {
            Success = true,
            Email = email
        };
    }

    public async Task LogoutAsync()
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(IdentityConstants.ApplicationScheme);
    }

    public async Task<bool> RegisterAsync(string email, string fullName, string password)
    {
        var user = new AppUser
        {
            Email = email,
            UserName = email,
            FullName = fullName
        };

        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }
}
