using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Contracts.SalesInventory;
using ModularMonolithTemplate.Inventory.Application.Abstractions;

namespace ModularMonolithTemplate.Inventory.Application.IntegrationEvents;

public class OrderShippedIntegrationEventHandler(IInventoryDbContext db)
    : INotificationHandler<OrderShippedIntegrationEvent>
{
    public async Task Handle(OrderShippedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var stockItem = await db.StockItems
            .FirstOrDefaultAsync(s => s.ProductId == notification.ProductId, cancellationToken);

        if (stockItem is null)
        {
            // Stock no encontrado para el producto
            return;
        }

        stockItem.DecreaseStock(notification.Quantity);

        await db.SaveChangesAsync(cancellationToken);
    }
}