using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.Login;
using ModularMonolithTemplate.Auth.Application.Logout;
using ModularMonolithTemplate.Auth.Application.Register;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var success = await _mediator.Send(command);
            if (!success) return BadRequest("Failed to register user.");
            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Logged in") : Unauthorized();
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
}
