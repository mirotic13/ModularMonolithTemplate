using Microsoft.AspNetCore.SignalR;
using ModularMonolithTemplate.Outbox.Application.Notifications;
using ModularMonolithTemplate.Outbox.Presentation.Hubs;

namespace ModularMonolithTemplate.Outbox.Presentation.Notifications;

public class SignalROutboxAlertNotifier(IHubContext<OutboxNotificationHub> hubContext)
    : IOutboxAlertNotifier
{
    public Task NotifyFailureAsync(int count, CancellationToken cancellationToken)
    {
        return hubContext.Clients.All.SendAsync(
            "OutboxFailureDetected",
            new
            {
                Count = count,
                Timestamp = DateTime.UtcNow
            },
            cancellationToken);
    }
}
