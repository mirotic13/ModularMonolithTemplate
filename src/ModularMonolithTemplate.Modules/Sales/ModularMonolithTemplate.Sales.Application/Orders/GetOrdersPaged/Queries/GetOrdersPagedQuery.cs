using MediatR;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Queries;

public record GetOrdersPagedQuery(GetOrdersPagedRequest Request) : IRequest<PagedResult<GetOrdersPagedResponse>>;
