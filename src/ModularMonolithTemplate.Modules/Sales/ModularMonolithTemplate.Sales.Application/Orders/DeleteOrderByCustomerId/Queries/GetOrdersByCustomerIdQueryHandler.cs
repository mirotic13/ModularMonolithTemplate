using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Contracts;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Queries;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

public class GetOrdersByCustomerIdQueryHandler(ISalesDbContext db) : IRequestHandler<GetOrdersByCustomerIdQuery, Result<List<GetOrdersByCustomerIdResponse>>>
{
    public async Task<Result<List<GetOrdersByCustomerIdResponse>>> Handle(GetOrdersByCustomerIdQuery query, CancellationToken cancellationToken)
    {
        var orders = await db.Orders
            .Include(o => o.Items)
            .Where(o => o.CustomerId == query.CustomerId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync(cancellationToken);

        if (orders.Count == 0)
            return Result<List<GetOrdersByCustomerIdResponse>>.Failure(Error.NotFound("No orders found for this customer."));

        var result = orders.Select(o => new GetOrdersByCustomerIdResponse
        {
            OrderId = o.Id,
            OrderDate = o.OrderDate,
            Status = o.Status.ToString(),
            Total = o.GetTotal()
        }).ToList();

        return Result<List<GetOrdersByCustomerIdResponse>>.Success(result);
    }
}
