using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Domain.Repositories;
using ModularMonolithTemplate.Auth.Infraestructure.Repositories;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class RepositoriesConfigurationExtension
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IRevokedTokenRepository, RevokedTokenRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}
