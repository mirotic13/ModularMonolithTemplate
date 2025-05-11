using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Contracts;
using ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Commands;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand { Request = request };
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginCommand { Request = request };
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [Authorize(Policy = "PartialTokenOnly")]
    [HttpPost("verify2fa")]
    public async Task<IActionResult> Verify2FA([FromBody] Verify2FARequest request)
    {
        var command = new Verify2FACommand { Request = request };
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [Authorize(Policy = "ValidTokenOnly")]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _mediator.Send(new LogoutCommand());
        return result.ToActionResult();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
    {
        var command = new RefreshTokenCommand { Request = request };
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }
}
