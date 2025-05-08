using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Contracts.SalesInventory;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Commands;

public class ShipOrderCommandHandler(ISalesDbContext db, IMediator mediator) : IRequestHandler<ShipOrderCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(ShipOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

        if (order is null)
            return Result<Unit>.Failure(Error.NotFound("Order not found."));

        if (order.Status == Domain.ValueObjects.OrderStatus.Cancelled)
            return Result<Unit>.Failure(Error.Domain("Cannot ship a cancelled order."));

        if (order.Status != Domain.ValueObjects.OrderStatus.Paid)
            return Result<Unit>.Failure(Error.Domain("Only paid orders can be shipped."));

        order.MarkAsShipped();

        await db.SaveChangesAsync(cancellationToken);

        foreach (var item in order.Items)
        {
            await mediator.Publish(new OrderShippedIntegrationEvent(item.ProductId, item.Quantity), cancellationToken);
        }

        return Result<Unit>.Success(Unit.Value);
    }
}