using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.UseCases.Logout;
using ModularMonolithTemplate.Auth.Application.UseCases.Login;
using ModularMonolithTemplate.Auth.Application.UseCases.Register;
using ModularMonolithTemplate.BuildingBlocks.Presentation;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Requests;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _mediator.Send(new RegisterCommand(request));
        return result.ToActionResult();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _mediator.Send(new LoginCommand(request));
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
