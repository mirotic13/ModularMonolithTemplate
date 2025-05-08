using MediatR;
using ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Queries;

public record GetAllStockQuery : IRequest<Result<List<GetAllStockResponse>>>;