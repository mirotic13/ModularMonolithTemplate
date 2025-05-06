using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;
using ModularMonolithTemplate.Modules.Auth.Application.Auth.Logout.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand { Request = request };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginCommand { Request = request };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Policy = "ValidTokenOnly")]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _mediator.Send(new LogoutCommand());
        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
    {
        var command = new RefreshTokenCommand { Request = request };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
