using ModularMonolithTemplate.Inventory.Domain.Events;
using ModularMonolithTemplate.SharedKernel.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Domain.Entities;

public class StockItem : BaseEntity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    private StockItem() { }

    public StockItem(Guid productId, int initialQuantity)
    {
        if (initialQuantity < 0)
            throw new ArgumentException("Initial quantity cannot be negative.");

        ProductId = productId;
        Quantity = initialQuantity;

        RaiseDomainEvent(new StockUpdatedDomainEvent(ProductId, Quantity));
    }

    public void IncreaseStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Quantity += amount;
        RaiseDomainEvent(new StockUpdatedDomainEvent(ProductId, Quantity));
    }

    public void DecreaseStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        if (Quantity < amount)
            throw new InvalidOperationException("Insufficient stock.");

        Quantity -= amount;
        RaiseDomainEvent(new StockUpdatedDomainEvent(ProductId, Quantity));
    }
}