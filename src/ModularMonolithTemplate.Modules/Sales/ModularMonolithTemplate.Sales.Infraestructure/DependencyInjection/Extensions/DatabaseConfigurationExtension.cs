using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Infraestructure.Persistence;
using ModularMonolithTemplate.Sales.Application.Abstractions;

namespace ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection.Extensions;

public static class DatabaseConfigurationExtension
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SalesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ISalesDbContext>(provider => provider.GetRequiredService<SalesDbContext>());

        return services;
    }
}
