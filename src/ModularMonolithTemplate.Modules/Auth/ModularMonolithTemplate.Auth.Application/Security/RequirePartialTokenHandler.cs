using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ModularMonolithTemplate.Auth.Application.Security;

public class RequirePartialTokenHandler(
    IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<RequirePartialToken>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequirePartialToken requirement)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var twoFactorAuthentication = user?.FindFirst("2fa")?.Value;

        if (string.IsNullOrWhiteSpace(twoFactorAuthentication))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        if (context.User.Identity?.IsAuthenticated == true &&
            twoFactorAuthentication == "false")
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
