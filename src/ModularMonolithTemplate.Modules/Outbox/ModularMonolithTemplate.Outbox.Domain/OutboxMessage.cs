namespace ModularMonolithTemplate.Outbox.Domain;

public class OutboxMessage
{
    public Guid Id { get; set; }
    public string EventType { get; set; } = default!;
    public string Payload { get; set; } = default!;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? LastAttemptAt { get; set; }
    public int AttemptCount { get; set; } = 0;
    public bool Processed { get; set; } = false;
    public bool Failed { get; set; } = false;
    public string? LastError { get; set; }
    public bool Alerted { get; set; } = false;
}
