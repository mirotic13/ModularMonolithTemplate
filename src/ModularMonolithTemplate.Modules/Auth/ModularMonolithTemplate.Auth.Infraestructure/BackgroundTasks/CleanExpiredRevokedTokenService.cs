using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolithTemplate.Auth.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Auth.Infraestructure.BackgroundTasks;

public class CleanExpiredRevokedTokensService(IServiceProvider serviceProvider, ILogger<CleanExpiredRevokedTokensService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ILogger<CleanExpiredRevokedTokensService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

                var now = DateTime.UtcNow;
                var expiredTokens = context.RevokedTokens
                    .Where(t => t.Expiration != null && t.Expiration < now);

                if (expiredTokens.Any())
                {
                    context.RevokedTokens.RemoveRange(expiredTokens);
                    await context.SaveChangesAsync(stoppingToken);
                    _logger.LogInformation($"Cleaned up {expiredTokens.Count()} expired revoked tokens.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cleaning expired revoked tokens");
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
