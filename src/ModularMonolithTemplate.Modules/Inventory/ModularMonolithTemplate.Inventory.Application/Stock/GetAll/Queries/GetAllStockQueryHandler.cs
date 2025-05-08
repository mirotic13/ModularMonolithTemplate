using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Application.Abstractions;
using ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Queries;

public class GetAllStockQueryHandler(IInventoryDbContext db) : IRequestHandler<GetAllStockQuery, Result<List<GetAllStockResponse>>>
{
    public async Task<Result<List<GetAllStockResponse>>> Handle(GetAllStockQuery query, CancellationToken cancellationToken)
    {
        var data = await db.StockItems
            .AsNoTracking()
            .Select(item => new GetAllStockResponse
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            })
            .ToListAsync(cancellationToken);

        return Result<List<GetAllStockResponse>>.Success(data);
    }
}