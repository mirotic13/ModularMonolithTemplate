using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application;
using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.SharedKernel.Infraestructure.DependencyInjection;

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
            .ConfigureValidation()
            .ConfigureHostedServices();

        services.AddSharedKernel<IAssemblyMarker>();

        services.AddHttpContextAccessor();

        return services;
    }
}