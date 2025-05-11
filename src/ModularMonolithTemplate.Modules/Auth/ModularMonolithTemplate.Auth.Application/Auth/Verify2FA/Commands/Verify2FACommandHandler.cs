using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Contracts;
using ModularMonolithTemplate.Auth.Application.Configuration;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Domain.Repositories;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Commands;

public class Verify2FACommandHandler(
    UserManager<ApplicationUser> userManager,
    ITokenService tokenService,
    IOptions<AuthOptions> authOptions,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<Verify2FACommand, Result<Verify2FAResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;
    private readonly AuthOptions _authOptions = authOptions.Value;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<Verify2FAResponse>> Handle(Verify2FACommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return Result<Verify2FAResponse>.Failure(Error.Unauthorized("Invalid credentials."));

        var is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
        var isTwoFactorAuthenticated = false;

        if (is2faEnabled)
        {
            if (string.IsNullOrWhiteSpace(request.Code))
                return Result<Verify2FAResponse>.Failure(Error.Custom("2FA_REQUIRED", "Two-factor authentication code is required."));

            if (_authOptions.UseMock2FA)
            {
                if (request.Code != "123456")
                    return Result<Verify2FAResponse>.Failure(Error.Unauthorized("Invalid 2FA code."));

                isTwoFactorAuthenticated = true;
            }
            else
            {
                isTwoFactorAuthenticated = await _userManager.VerifyTwoFactorTokenAsync(
                    user, TokenOptions.DefaultAuthenticatorProvider, request.Code);

                if (!isTwoFactorAuthenticated)
                    return Result<Verify2FAResponse>.Failure(Error.Unauthorized("Invalid 2FA code."));
            }
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateToken(user, roles, isTwoFactorAuthenticated);

        var refreshToken = new RefreshToken
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        var response = new Verify2FAResponse
        {
            Token = token,
            RefreshToken = refreshToken.Token,
        };

        return Result<Verify2FAResponse>.Success(response);
    }
}
