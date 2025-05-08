using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Commands;

public class RemoveItemFromOrderCommandHandler(ISalesDbContext db) : IRequestHandler<RemoveItemFromOrderCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(RemoveItemFromOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

        if (order is null)
            return Result<Unit>.Failure(Error.NotFound("Order not found."));

        var item = order.Items.FirstOrDefault(i => i.Id == command.OrderItemId);
        if (item is null)
            return Result<Unit>.Failure(Error.NotFound("Order item not found."));

        order.RemoveItem(item.Id);

        await db.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}