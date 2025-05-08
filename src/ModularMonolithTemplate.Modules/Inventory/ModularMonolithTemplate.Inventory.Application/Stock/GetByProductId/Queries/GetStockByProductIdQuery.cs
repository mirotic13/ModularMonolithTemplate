using MediatR;
using ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Queries;

public record GetStockByProductIdQuery(Guid ProductId) : IRequest<Result<GetStockByProductIdResponse>>;