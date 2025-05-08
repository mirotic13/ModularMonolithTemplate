using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Commands;

public record RemoveItemFromOrderCommand(Guid OrderId, Guid OrderItemId) : IRequest<Result<Unit>>;