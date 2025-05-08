using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Sales.Application.Orders.MarkAsPaid.Commands;

public record MarkOrderAsPaidCommand(Guid OrderId) : IRequest<Result<Unit>>;
