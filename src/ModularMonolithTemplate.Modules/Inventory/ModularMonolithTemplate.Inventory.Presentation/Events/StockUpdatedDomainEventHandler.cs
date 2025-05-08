using MediatR;
using Microsoft.AspNetCore.SignalR;
using ModularMonolithTemplate.Inventory.Domain.Events;
using ModularMonolithTemplate.Inventory.Presentation.Hubs;

namespace ModularMonolithTemplate.Inventory.Presentation.Events;

public class StockUpdatedDomainEventHandler(IHubContext<StockHub> hub) : INotificationHandler<StockUpdatedDomainEvent>
{
    public async Task Handle(StockUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await hub.Clients.All.SendAsync("StockUpdated", new
        {
            notification.ProductId,
            notification.Quantity
        }, cancellationToken);
    }
}