using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Contracts;
using ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Contracts;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Queries;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Queries;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Contracts;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Queries;
using ModularMonolithTemplate.Sales.Application.Orders.MarkAsPaid.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Commands;
using ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Commands;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Presentation.Controllers;

[Authorize(Policy = "ValidTokenOnly")]
[ApiController]
[Route("api/sales/[controller]")]
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetOrderByIdQuery(id);
        var result = await _mediator.Send(query);
        return result.ToActionResult();
    }

    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] GetOrdersPagedRequest request)
    {
        var result = await _mediator.Send(new GetOrdersPagedQuery(request));
        return result.ToActionResultPaged();
    }

    [HttpPut("{id:guid}/mark-paid")]
    public async Task<IActionResult> MarkAsPaid([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new MarkOrderAsPaidCommand(id));
        return result.ToActionResult();
    }

    [HttpPut("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new CancelOrderCommand(id));
        return result.ToActionResult();
    }

    [HttpPut("{id:guid}/ship")]
    public async Task<IActionResult> Ship([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new ShipOrderCommand(id));
        return result.ToActionResult();
    }

    [HttpPut("{id:guid}/add-item")]
    public async Task<IActionResult> AddItem([FromRoute] Guid id, [FromBody] AddItemToOrderRequest request)
    {
        var command = new AddItemToOrderCommand(id, request);
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [HttpPut("{id:guid}/remove-item/{itemId:guid}")]
    public async Task<IActionResult> RemoveItem(Guid id, Guid itemId)
    {
        var result = await _mediator.Send(new RemoveItemFromOrderCommand(id, itemId));
        return result.ToActionResult();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteOrderCommand(id));
        return result.ToActionResult();
    }

    [HttpGet("customer/{customerId:guid}")]
    public async Task<IActionResult> GetByCustomerId(Guid customerId)
    {
        var result = await _mediator.Send(new GetOrdersByCustomerIdQuery(customerId));
        return result.ToActionResult();
    }
}
