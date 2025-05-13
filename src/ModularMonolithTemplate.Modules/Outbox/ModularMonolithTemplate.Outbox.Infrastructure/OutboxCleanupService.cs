using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolithTemplate.Outbox.Domain;

namespace ModularMonolithTemplate.Outbox.Infrastructure;

public class OutboxCleanupService<TDbContext>(
    IServiceProvider serviceProvider,
    ILogger<OutboxCleanupService<TDbContext>> logger)
    : BackgroundService where TDbContext : DbContext
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.UtcNow;

            var nextRun = now.Date.AddDays(1).AddHours(3);
            var delay = nextRun - now;
            await Task.Delay(delay, stoppingToken);

            try
            {
                using var scope = serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TDbContext>();

                var deletedCount = await db.Set<OutboxMessage>()
                    .Where(m => m.Processed && !m.Failed && m.Created < DateTime.UtcNow.AddDays(-7))
                    .ExecuteDeleteAsync(stoppingToken);

                logger.LogInformation("Outbox cleanup: {Count} processed messages deleted.", deletedCount);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during outbox cleanup.");
            }
        }
    }
}
