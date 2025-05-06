using ModularMonolithTemplate.SharedKernel.Domain;

namespace ModularMonolithTemplate.Inventory.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Sku { get; private set; } = default!;
    public int Stock { get; private set; }

    public void AdjustStock(int quantity)
    {
        Stock += quantity;
    }
}

