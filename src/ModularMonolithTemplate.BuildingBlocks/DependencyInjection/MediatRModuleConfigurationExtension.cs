using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithTemplate.BuildingBlocks.DependencyInjection;

public static class MediatRModuleConfigurationExtension
{
    public static IServiceCollection ConfigureHandlers<T>(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<T>();
        });

        return services;
    }
}
