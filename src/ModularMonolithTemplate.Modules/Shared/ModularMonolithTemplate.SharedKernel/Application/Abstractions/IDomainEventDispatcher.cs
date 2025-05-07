using ModularMonolithTemplate.SharedKernel.Domain.Abstractions;

namespace ModularMonolithTemplate.SharedKernel.Application.Abstractions;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default);
}
