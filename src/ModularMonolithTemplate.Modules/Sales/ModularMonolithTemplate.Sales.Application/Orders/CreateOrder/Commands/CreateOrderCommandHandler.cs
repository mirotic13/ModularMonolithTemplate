using MediatR;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Contracts;
using ModularMonolithTemplate.Sales.Domain.Entities;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Commands;

public class CreateOrderCommandHandler(ISalesDbContext db) : IRequestHandler<CreateOrderCommand, Result<CreateOrderResponse>>
{
    private readonly ISalesDbContext _db = db;

    public async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var order = new Order(request.CustomerId);

        foreach (var item in request.Items)
        {
            var orderItem = new OrderItem(item.ProductId, item.Quantity, item.UnitPrice);
            order.AddItem(orderItem);
        }

        await _db.Orders.AddAsync(order, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return Result<CreateOrderResponse>.Success(new CreateOrderResponse { OrderId = order.Id });
    }
}
