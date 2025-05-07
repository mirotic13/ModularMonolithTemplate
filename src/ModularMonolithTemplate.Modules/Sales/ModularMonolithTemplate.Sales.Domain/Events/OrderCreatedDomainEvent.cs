using ModularMonolithTemplate.SharedKernel.Domain.Abstractions;

namespace ModularMonolithTemplate.Sales.Domain.Events;

public class OrderCreatedDomainEvent(Guid orderId, Guid customerId) : IDomainEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid CustomerId { get; } = customerId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
