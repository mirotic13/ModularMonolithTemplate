using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolithTemplate.Outbox.Domain;

namespace ModularMonolithTemplate.Outbox.Infrastructure;

public class OutboxProcessor<TDbContext>(IServiceProvider serviceProvider, ILogger<OutboxProcessor<TDbContext>> logger)
    : BackgroundService where TDbContext : DbContext
{
    private const int MaxAttempts = 3;
    private const int IntervalSeconds = 10;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TDbContext>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var pendingMessages = await db.Set<OutboxMessage>()
                .Where(m => !m.Processed && !m.Failed)
                .OrderBy(m => m.Created)
                .Take(10)
                .ToListAsync(stoppingToken);

            foreach (var message in pendingMessages)
            {
                try
                {
                    var type = Type.GetType(message.EventType)!;
                    var integrationEvent = JsonSerializer.Deserialize(message.Payload, type)!;

                    await mediator.Publish(integrationEvent, stoppingToken);

                    message.Processed = true;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error procesando evento {EventType}", message.EventType);

                    message.AttemptCount++;
                    message.LastAttemptAt = DateTime.UtcNow;
                    message.LastError = ex.Message;

                    if (message.AttemptCount >= MaxAttempts)
                        message.Failed = true;
                }
            }

            await db.SaveChangesAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(IntervalSeconds), stoppingToken);
        }
    }
}
