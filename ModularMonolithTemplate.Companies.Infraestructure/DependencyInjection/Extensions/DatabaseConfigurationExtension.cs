using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Companies.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection.Extensions;

public static class DatabaseConfigurationExtension
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CompaniesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
