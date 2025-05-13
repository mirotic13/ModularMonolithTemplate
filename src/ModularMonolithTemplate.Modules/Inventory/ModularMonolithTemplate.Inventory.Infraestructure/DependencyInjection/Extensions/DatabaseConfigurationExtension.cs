using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Application.Abstractions;
using ModularMonolithTemplate.Inventory.Infrastructure.Persistence;

namespace ModularMonolithTemplate.Inventory.Infrastructure.DependencyInjection.Extensions;

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
