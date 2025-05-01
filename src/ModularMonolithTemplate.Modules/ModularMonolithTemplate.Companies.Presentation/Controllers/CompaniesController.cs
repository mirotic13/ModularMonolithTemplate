using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Companies.Application.GetDemoCompany;

namespace ModularMonolithTemplate.Companies.Presentation.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("demo")]
    public async Task<IActionResult> GetDemoCompany()
    {
        var result = await _mediator.Send(new GetDemoCompanyQuery());
        return Ok(result);
    }
}
