using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.UseCases.Logout;
using ModularMonolithTemplate.Auth.Application.UseCases.Login;
using ModularMonolithTemplate.Auth.Application.UseCases.Register;
using ModularMonolithTemplate.BuildingBlocks.Presentation;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var user = User.Identity?.Name ?? "Unknown";
        return Ok($"You are authenticated as {user}");
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutCommand());
        return Ok("Logged out");
    }
}
