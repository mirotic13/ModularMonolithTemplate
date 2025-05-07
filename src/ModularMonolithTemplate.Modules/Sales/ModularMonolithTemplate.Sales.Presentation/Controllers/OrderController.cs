using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Presentation.Controllers;

[ApiController]
[Route("api/sales/orders")]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrderCommand(request);
        Result<CreateOrderResponse> result = await _mediator.Send(command);
        return result.ToActionResult();
    }
}
