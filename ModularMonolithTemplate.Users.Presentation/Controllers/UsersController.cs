using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Users.Application.GetDemoUser;

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
        return Ok(result);
    }
}
