using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Infraestructure.BackgroundTasks;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class HostedServicesConfigurationExtension
{
    public static IServiceCollection ConfigureHostedServices(this IServiceCollection services)
    {
        services
            .AddHostedService<CleanExpiredRevokedTokensService>()
            .AddHostedService<CleanExpiredRefreshTokensService>();

        return services;
    }
}
