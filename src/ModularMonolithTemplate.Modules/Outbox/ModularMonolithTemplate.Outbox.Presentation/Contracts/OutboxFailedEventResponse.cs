namespace ModularMonolithTemplate.Outbox.Presentation.Contracts;

public record OutboxFailedEventResponse(
    Guid Id,
    string EventType,
    string EventName,
    string? LastError,
    int AttemptCount,
    DateTime? LastAttemptAt,
    DateTime Created
);
