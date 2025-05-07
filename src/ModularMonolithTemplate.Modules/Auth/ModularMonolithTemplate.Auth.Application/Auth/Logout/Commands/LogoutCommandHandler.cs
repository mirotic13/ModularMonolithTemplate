using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Contracts;
using ModularMonolithTemplate.Auth.Application.Repositories;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.SharedKernel.Application.Responses;
using System.Security.Claims;

namespace ModularMonolithTemplate.Modules.Auth.Application.Auth.Logout.Commands;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<LogoutResponse>>
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IRevokedTokenRepository _revokedTokenRepository;

    public LogoutCommandHandler(
        IHttpContextAccessor httpContext,
        UserManager<ApplicationUser> userManager,
        IRevokedTokenRepository revokedTokenRepository)
    {
        _httpContext = httpContext;
        _userManager = userManager;
        _revokedTokenRepository = revokedTokenRepository;
    }

    public async Task<Result<LogoutResponse>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var user = _httpContext.HttpContext?.User;

        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var jti = user?.FindFirst("jti")?.Value;
        var expRaw = user?.FindFirst("exp")?.Value;

        if (string.IsNullOrWhiteSpace(userIdStr) || string.IsNullOrWhiteSpace(jti))
            return Result<LogoutResponse>.Failure(Error.Unauthorized("Invalid token."));

        var expiration = long.TryParse(expRaw, out var expSeconds)
            ? DateTimeOffset.FromUnixTimeSeconds(expSeconds).UtcDateTime
            : (DateTime?)null;

        var userEntity = await _userManager.FindByIdAsync(userIdStr);
        if (userEntity == null)
            return Result<LogoutResponse>.Failure(Error.NotFound("User not found."));

        var alreadyRevoked = await _revokedTokenRepository.IsTokenRevokedAsync(jti);
        if (!alreadyRevoked)
        {
            await _revokedTokenRepository.RevokeTokenAsync(jti, userEntity.Id, expiration);
        }

        return Result<LogoutResponse>.Success(new LogoutResponse());
    }
}
