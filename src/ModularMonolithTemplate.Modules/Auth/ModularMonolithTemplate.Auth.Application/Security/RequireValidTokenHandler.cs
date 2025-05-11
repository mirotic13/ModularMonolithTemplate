using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ModularMonolithTemplate.Auth.Application.Repositories;

namespace ModularMonolithTemplate.Auth.Application.Security;

public class RequireValidTokenHandler(
    IHttpContextAccessor httpContextAccessor,
    IRevokedTokenRepository revokedTokenRepository) : AuthorizationHandler<RequireValidToken>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IRevokedTokenRepository _revokedTokenRepository = revokedTokenRepository;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireValidToken requirement)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var jti = user?.FindFirst("jti")?.Value;

        if (string.IsNullOrWhiteSpace(jti))
        {
            context.Fail();
            return;
        }

        var isRevoked = await _revokedTokenRepository.IsTokenRevokedAsync(jti);
        if (isRevoked)
        {
            context.Fail();
            return;
        }

        var twoFactorPassed = user?.FindFirst("2fa")?.Value;
        if (!string.Equals(twoFactorPassed, "true", StringComparison.OrdinalIgnoreCase))
        {
            context.Fail();
            return;
        }

        context.Succeed(requirement);
    }
}
