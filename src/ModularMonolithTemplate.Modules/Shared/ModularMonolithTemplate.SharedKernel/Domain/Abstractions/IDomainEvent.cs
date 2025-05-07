using MediatR;

namespace ModularMonolithTemplate.SharedKernel.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
