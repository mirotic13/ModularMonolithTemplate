using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection.Extensions;

namespace ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection;

public static class InventoryModule
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration);

        return services;
    }
}