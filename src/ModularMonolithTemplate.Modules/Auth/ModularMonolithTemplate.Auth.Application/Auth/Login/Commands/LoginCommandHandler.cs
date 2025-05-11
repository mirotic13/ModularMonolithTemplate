using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

public class LoginCommandHandler(
    UserManager<ApplicationUser> userManager,
    ITokenService tokenService) : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<Result<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return Result<LoginResponse>.Failure(Error.Unauthorized("Invalid credentials."));

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            return Result<LoginResponse>.Failure(Error.Unauthorized("Invalid credentials."));

        var is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
        var isTwoFactorAuthenticated = !is2faEnabled;

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateToken(user, roles, isTwoFactorAuthenticated);

        var response = new LoginResponse
        {
            Token = token,
            TwoFactorEnabled = is2faEnabled,
            UserName = user.UserName ?? "",
            Roles = [.. roles]
        };

        return Result<LoginResponse>.Success(response);
    }
}
