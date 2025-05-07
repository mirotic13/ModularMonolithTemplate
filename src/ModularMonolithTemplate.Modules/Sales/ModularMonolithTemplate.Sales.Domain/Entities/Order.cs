using ModularMonolithTemplate.Sales.Domain.Events;
using ModularMonolithTemplate.Sales.Domain.ValueObjects;
using ModularMonolithTemplate.SharedKernel.Domain.Entities;

namespace ModularMonolithTemplate.Sales.Domain.Entities;

public class Order : BaseEntity
{
    private readonly List<OrderItem> _items = new();

    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { }

    public Order(Guid customerId)
    {
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.Pending;

        RaiseDomainEvent(new OrderCreatedDomainEvent(Id, customerId));
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is not null)
            _items.Remove(item);
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be marked as paid.");

        Status = OrderStatus.Paid;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Shipped orders cannot be cancelled.");

        Status = OrderStatus.Cancelled;
    }

    public decimal GetTotal() => _items.Sum(i => i.Subtotal);
}
