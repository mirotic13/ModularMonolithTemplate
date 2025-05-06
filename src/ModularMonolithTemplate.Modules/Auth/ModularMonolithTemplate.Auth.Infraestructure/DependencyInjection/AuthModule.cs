using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application;
using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.SharedKernel.DependencyInjection;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureIdentity(configuration)
            .ConfigureOptions(configuration)
            .ConfigureRepositories()
            .ConfigureServices()
            .ConfigureSecurity()
            .ConfigureHandlers<IAssemblyMarker>()
            .ConfigureExceptionHandler()
            .ConfigureValidation()
            .ConfigureLogger();

        services.AddHttpContextAccessor();

        return services;
    }
}