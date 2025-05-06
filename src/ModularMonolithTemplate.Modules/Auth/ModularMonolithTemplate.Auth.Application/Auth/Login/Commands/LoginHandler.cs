using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;
using ModularMonolithTemplate.Auth.Application.Exceptions;
using ModularMonolithTemplate.Auth.Application.Repositories;
using Microsoft.Extensions.Options;
using ModularMonolithTemplate.Auth.Application.Configuration;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

public class LoginCommandHandler(
    UserManager<ApplicationUser> userManager,
    ITokenService tokenService,
    IRefreshTokenRepository refreshTokenRepository,
    IOptions<AuthOptions> authOptions) : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly AuthOptions _authOptions = authOptions.Value;

    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new UnauthorizedAccessException("Invalid credentials");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            throw new UnauthorizedAccessException("Invalid credentials");

        var is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
        var passed2fa = false;

        if (is2faEnabled)
        {
            if (string.IsNullOrWhiteSpace(request.TwoFactorCode))
                throw new TwoFactorRequiredException("2FA code is required");

            if (_authOptions.UseMock2FA)
            {
                if (request.TwoFactorCode != "123456")
                    throw new UnauthorizedAccessException("Invalid 2FA code");

                passed2fa = true;
            }
            else
            {
                passed2fa = await _userManager.VerifyTwoFactorTokenAsync(
                    user, TokenOptions.DefaultAuthenticatorProvider, request.TwoFactorCode);

                if (!passed2fa)
                    throw new UnauthorizedAccessException("Invalid 2FA code");
            }
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateToken(user, roles, passed2fa);

        var refreshToken = new RefreshToken
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        return new LoginResponse
        {
            Token = token,
            TwoFactorPassed = passed2fa,
            UserName = user.UserName ?? "",
            Roles = [.. roles],
            RefreshToken = refreshToken.Token
        };
    }
}
