using ModularMonolithTemplate.SharedKernel.Domain.Abstractions;

namespace ModularMonolithTemplate.Inventory.Domain.Events;

public class StockUpdatedDomainEvent(Guid productId, int quantity) : IDomainEvent
{
    public Guid ProductId { get; } = productId;
    public int Quantity { get; } = quantity;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}