using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.BuildingBlocks.Logging;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureIdentity()
            .ConfigureServices()
            .ConfigureHandlers()
            .ConfigureCookie()
            .ConfigureLogger();

        return services;
    }
}
