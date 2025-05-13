namespace ModularMonolithTemplate.Outbox.Application;

public interface IEventPublisher
{
    Task EnqueueAsync(object integrationEvent, CancellationToken cancellationToken = default);
}
