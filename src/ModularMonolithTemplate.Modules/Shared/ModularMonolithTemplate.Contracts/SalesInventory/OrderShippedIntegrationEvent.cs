using MediatR;

namespace ModularMonolithTemplate.Contracts.SalesInventory;

public class OrderShippedIntegrationEvent(Guid productId, int quantity) : INotification
{
    public Guid ProductId { get; } = productId;
    public int Quantity { get; } = quantity;
}