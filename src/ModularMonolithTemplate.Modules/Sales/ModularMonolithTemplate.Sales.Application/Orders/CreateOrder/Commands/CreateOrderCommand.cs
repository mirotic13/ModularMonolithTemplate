using MediatR;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Commands;

public record CreateOrderCommand(CreateOrderRequest Request) : IRequest<Result<CreateOrderResponse>>;
