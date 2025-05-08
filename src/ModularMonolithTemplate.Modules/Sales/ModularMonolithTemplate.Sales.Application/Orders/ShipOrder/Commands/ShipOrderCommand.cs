using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Commands;

public record ShipOrderCommand(Guid OrderId) : IRequest<Result<Unit>>;