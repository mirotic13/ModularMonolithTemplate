using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Inventory.Application;
using ModularMonolithTemplate.Inventory.Infrastructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.Inventory.Infrastructure.Persistence;
using ModularMonolithTemplate.SharedKernel.Infraestructure.DependencyInjection;

namespace ModularMonolithTemplate.Inventory.Infrastructure.DependencyInjection;

public static class InventoryModule
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureValidations();

        services.AddSignalR();
        services.AddSharedKernel<IAssemblyMarker>();
        services.AddHttpContextAccessor();

        return services;
    }

    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
        await InventoryDbInitializer.InitializeAsync(context);
    }
}