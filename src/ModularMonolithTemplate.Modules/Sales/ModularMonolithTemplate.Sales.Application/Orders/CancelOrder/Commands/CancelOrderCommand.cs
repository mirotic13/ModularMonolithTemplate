using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Commands;

public record CancelOrderCommand(Guid OrderId) : IRequest<Result<Unit>>;