using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;
using ModularMonolithTemplate.Auth.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Application.Auth.Register.Commands;

public class RegisterHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,
            EmailConfirmed = true,  // Cambiar a false y configurar la activacion por correo en caso real
            TwoFactorEnabled = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new ApplicationException($"Register failed: {errors}");
        }

        return new RegisterResponse
        {
            UserId = user.Id,
            UserName = user.UserName ?? "",
            Email = user.Email ?? "",
            TwoFactorEnabled = user.TwoFactorEnabled
        };
    }
}
