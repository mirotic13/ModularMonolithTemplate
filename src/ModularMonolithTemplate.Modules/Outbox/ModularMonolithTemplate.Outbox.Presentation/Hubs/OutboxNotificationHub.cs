using Microsoft.AspNetCore.SignalR;

namespace ModularMonolithTemplate.Outbox.Presentation.Hubs;

public class OutboxNotificationHub : Hub
{
    public const string HubUrl = "/hubs/outbox-alerts";
}
