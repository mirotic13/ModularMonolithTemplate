using ModularMonolithTemplate.SharedKernel.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Domain.Entities;

public class StockEntry : BaseEntity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public string Type { get; private set; } = default!;
}

