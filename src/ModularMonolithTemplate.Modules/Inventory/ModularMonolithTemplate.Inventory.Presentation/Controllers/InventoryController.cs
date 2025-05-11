using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Queries;
using ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Queries;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Inventory.Presentation.Controllers;

[Authorize(Policy = "ValidTokenOnly")]
[ApiController]
[Route("api/[controller]")]
public class InventoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("product/{productId:guid}")]
    public async Task<IActionResult> GetStock(Guid productId)
    {
        var result = await _mediator.Send(new GetStockByProductIdQuery(productId));
        return result.ToActionResult();
    }

    [HttpGet("stock")]
    public async Task<IActionResult> GetAllStock()
    {
        var result = await _mediator.Send(new GetAllStockQuery());
        return result.ToActionResult();
    }
}
