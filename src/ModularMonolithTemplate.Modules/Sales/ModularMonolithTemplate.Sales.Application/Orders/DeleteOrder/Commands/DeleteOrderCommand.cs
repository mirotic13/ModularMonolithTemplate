using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Commands;

public record DeleteOrderCommand(Guid OrderId) : IRequest<Result<Unit>>;