using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Presentation.Controllers;

[ApiController]
[Route("auth/demo")]
public class AuthDemoController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDemoRequest request)
    {
        var command = new LoginDemoCommand { Request = request };
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [Authorize]
    [HttpGet("auth-check")]
    public async Task<IActionResult> Check()
    {
        var result = await _mediator.Send(new IsAuthenticatedDemoQuery());
        return result.ToActionResult();
    }
}
