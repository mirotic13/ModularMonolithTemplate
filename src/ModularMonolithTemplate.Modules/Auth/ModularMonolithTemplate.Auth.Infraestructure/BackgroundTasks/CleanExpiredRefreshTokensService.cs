using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolithTemplate.Auth.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Auth.Infraestructure.BackgroundTasks;

public class CleanExpiredRefreshTokensService(IServiceProvider serviceProvider, ILogger<CleanExpiredRefreshTokensService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ILogger<CleanExpiredRefreshTokensService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

                var now = DateTime.UtcNow;
                var expired = context.RefreshTokens
                    .Where(t => t.ExpiresAt < now || t.Revoked);

                if (expired.Any())
                {
                    context.RefreshTokens.RemoveRange(expired);
                    await context.SaveChangesAsync(stoppingToken);
                    _logger.LogInformation($"[RefreshTokens] Limpieza: {expired.Count()} eliminados.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[RefreshTokens] Error durante la limpieza de tokens expirados");
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
