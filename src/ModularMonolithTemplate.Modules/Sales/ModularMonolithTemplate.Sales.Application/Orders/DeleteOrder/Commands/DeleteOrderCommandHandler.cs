using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Commands;

public class DeleteOrderCommandHandler(ISalesDbContext db) : IRequestHandler<DeleteOrderCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

        if (order is null)
            return Result<Unit>.Failure(Error.NotFound("Order not found."));

        db.Orders.Remove(order);
        await db.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}