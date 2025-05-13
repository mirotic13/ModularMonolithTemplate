namespace ModularMonolithTemplate.Outbox.Application.Notifications;

public interface IOutboxAlertNotifier
{
    Task NotifyFailureAsync(int count, CancellationToken cancellationToken);
}
