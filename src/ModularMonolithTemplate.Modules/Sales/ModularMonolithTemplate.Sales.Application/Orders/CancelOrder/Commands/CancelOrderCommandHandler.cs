using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Commands;

public class CancelOrderCommandHandler(ISalesDbContext db) : IRequestHandler<CancelOrderCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await db.Orders
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

        if (order is null)
            return Result<Unit>.Failure(Error.NotFound("Order not found."));

        try
        {
            order.Cancel();
        }
        catch (InvalidOperationException ex)
        {
            return Result<Unit>.Failure(Error.Domain(ex.Message));
        }

        await db.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value);
    }
}