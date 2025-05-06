using ModularMonolithTemplate.Auth.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Application.Services;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user, IList<string> roles, bool isTwoFactorAuthenticated);
}
