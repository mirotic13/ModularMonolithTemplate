using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Infraestructure.Persistence;
using ModularMonolithTemplate.Inventory.Application.Abstractions;

namespace ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection.Extensions;

public static class DatabaseConfigurationExtension
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IInventoryDbContext>(provider => provider.GetRequiredService<InventoryDbContext>());

        return services;
    }
}
