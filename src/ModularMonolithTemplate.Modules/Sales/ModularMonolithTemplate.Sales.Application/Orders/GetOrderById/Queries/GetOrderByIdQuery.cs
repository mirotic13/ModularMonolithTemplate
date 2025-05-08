using MediatR;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Queries;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<Result<GetOrderByIdResponse>>;
