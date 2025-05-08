using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.Sales.Domain.Entities;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Commands;

public class AddItemToOrderCommandHandler(ISalesDbContext db) : IRequestHandler<AddItemToOrderCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(AddItemToOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

        if (order is null)
            return Result<Unit>.Failure(Error.NotFound("Order not found."));

        var item = new OrderItem(
            productId: command.Request.ProductId,
            quantity: command.Request.Quantity,
            unitPrice: command.Request.UnitPrice
        );

        order.AddItem(item);

        await db.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}