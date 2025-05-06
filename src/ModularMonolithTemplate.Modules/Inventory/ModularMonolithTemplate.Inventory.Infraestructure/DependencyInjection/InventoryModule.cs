using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection.Extensions;

namespace ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection;

public static class InventoryModule
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            //.ConfigureHandlers<AssemblyReference>()
            .ConfigureExceptionHandler()
            .ConfigureLogger();

        return services;
    }
}