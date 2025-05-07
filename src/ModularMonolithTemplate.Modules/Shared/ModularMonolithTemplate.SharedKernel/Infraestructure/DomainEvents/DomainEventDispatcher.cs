using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Domain.Abstractions;

namespace ModularMonolithTemplate.SharedKernel.Infraestructure.DomainEvents;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator) => _mediator = mediator;

    public async Task DispatchEventsAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in events)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
    }
}
