using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.BuildingBlocks.Presentation;
using ModularMonolithTemplate.Users.Application.UseCases.GetDemoUser;
using ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;
using ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

namespace ModularMonolithTemplate.Users.Presentation.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("demo")]
    public async Task<IActionResult> GetDemoUser()
    {
        var result = await _mediator.Send(new GetDemoUserQuery());
        return result.ToActionResult();
    }

    [HttpGet("demo/isActive")]
    public async Task<IActionResult> GetDemoActiveUser()
    {
        var result = await _mediator.Send(new GetDemoUserDomainErrorQuery());
        return result.ToActionResult();
    }

    [HttpGet("demo/isValid")]
    public async Task<IActionResult> GetDemoValidUser()
    {
        var result = await _mediator.Send(new GetDemoUserValidationErrorQuery());
        return result.ToActionResult();
    }
}
