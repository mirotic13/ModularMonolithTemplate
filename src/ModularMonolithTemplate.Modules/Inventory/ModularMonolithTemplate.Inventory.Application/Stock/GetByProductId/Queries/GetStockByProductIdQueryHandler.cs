using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Application.Abstractions;
using ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Queries;

public class GetStockByProductIdQueryHandler(IInventoryDbContext db) : IRequestHandler<GetStockByProductIdQuery, Result<GetStockByProductIdResponse>>
{
    public async Task<Result<GetStockByProductIdResponse>> Handle(GetStockByProductIdQuery query, CancellationToken cancellationToken)
    {
        var stock = await db.StockItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == query.ProductId, cancellationToken);

        if (stock is null)
            return Result<GetStockByProductIdResponse>.Failure(Error.NotFound("Stock not found."));

        return Result<GetStockByProductIdResponse>.Success(new GetStockByProductIdResponse
        {
            ProductId = stock.ProductId,
            Quantity = stock.Quantity
        });
    }
}