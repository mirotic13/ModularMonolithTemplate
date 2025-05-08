using MediatR;
using ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Commands;

public record AddItemToOrderCommand(Guid OrderId, AddItemToOrderRequest Request) : IRequest<Result<Unit>>;