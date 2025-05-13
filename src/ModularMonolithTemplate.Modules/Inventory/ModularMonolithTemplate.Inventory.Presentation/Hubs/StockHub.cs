using Microsoft.AspNetCore.SignalR;

namespace ModularMonolithTemplate.Inventory.Presentation.Hubs;

public class StockHub : Hub
{
    public const string HubUrl = "/hub/inventory";
}