using ModularMonolithTemplate.SharedKernel.Domain;

namespace ModularMonolithTemplate.Sales.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public decimal TotalAmount => Items.Sum(i => i.Quantity * i.UnitPrice);
}

public class OrderItem
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
}
