using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolithTemplate.Outbox.Application.Notifications;
using ModularMonolithTemplate.Outbox.Domain;

namespace ModularMonolithTemplate.Outbox.Infrastructure;

public class OutboxFailureAlertService<TDbContext>(
    IServiceProvider serviceProvider,
    ILogger<OutboxFailureAlertService<TDbContext>> logger,
    IOutboxAlertNotifier notifier)
    : BackgroundService where TDbContext : DbContext
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TDbContext>();

                var failedEvents = await db.Set<OutboxMessage>()
                    .Where(m => m.Failed && !m.Alerted)
                    .ToListAsync(stoppingToken);

                if (failedEvents.Count != 0)
                {
                    logger.LogWarning("Hay {Count} eventos en el outbox que han fallado y superado el máximo de reintentos.", failedEvents.Count);

                    await notifier.NotifyFailureAsync(failedEvents.Count, stoppingToken);

                    foreach (var ev in failedEvents)
                        ev.Alerted = true;

                    await db.SaveChangesAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error comprobando eventos outbox fallidos.");
            }

            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
        }
    }
}