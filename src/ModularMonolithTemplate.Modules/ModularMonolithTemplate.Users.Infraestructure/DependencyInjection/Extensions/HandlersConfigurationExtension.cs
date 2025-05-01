using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Users.Application.Configuration;

namespace ModularMonolithTemplate.Users.Infraestructure.DependencyInjection.Extensions
{
    public static class HandlersConfigurationExtension
    {
        public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AssemblyReference>();
            });

            return services;
        }
    }
}
