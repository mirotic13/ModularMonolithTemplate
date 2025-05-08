using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Application.Abstractions;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Queries;

public class GetOrdersPagedQueryHandler(ISalesDbContext db) : IRequestHandler<GetOrdersPagedQuery, PagedResult<GetOrdersPagedResponse>>
{
    public async Task<PagedResult<GetOrdersPagedResponse>> Handle(GetOrdersPagedQuery query, CancellationToken cancellationToken)
    {
        var request = query.Request;

        var total = await db.Orders.CountAsync(cancellationToken);

        var orders = await db.Orders
            .Include(o => o.Items)
            .OrderByDescending(o => o.OrderDate)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var data = orders.Select(o => new GetOrdersPagedResponse
        {
            OrderId = o.Id,
            CustomerId = o.CustomerId,
            OrderDate = o.OrderDate,
            Status = o.Status.ToString(),
            Total = o.GetTotal()
        }).ToList();

        return PagedResult<GetOrdersPagedResponse>.Success(data, request.Page, request.PageSize, total);
    }
}
