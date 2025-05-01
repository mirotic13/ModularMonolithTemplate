using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Users.Infraestructure.Persistence;

namespace ModularMonolithTemplate.Users.Infraestructure.DependencyInjection.Extensions;

public static class DatabaseConfigurationExtension
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
