using MediatR;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Queries;

public record GetOrdersByCustomerIdQuery(Guid CustomerId) : IRequest<Result<List<GetOrdersByCustomerIdResponse>>>;