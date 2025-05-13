using System.Text.Json;
using ModularMonolithTemplate.Outbox.Domain;
using ModularMonolithTemplate.Outbox.Application;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolithTemplate.Outbox.Infrastructure;

public class EventPublisherService<TDbContext>(TDbContext dbContext)
    : IEventPublisher where TDbContext : DbContext
{
    public async Task EnqueueAsync(object integrationEvent, CancellationToken cancellationToken = default)
    {
        var message = new OutboxMessage
        {
            Id = Guid.NewGuid(),
            EventType = integrationEvent.GetType().AssemblyQualifiedName!,
            Payload = JsonSerializer.Serialize(integrationEvent)
        };

        await dbContext.Set<OutboxMessage>().AddAsync(message, cancellationToken);
    }
}
