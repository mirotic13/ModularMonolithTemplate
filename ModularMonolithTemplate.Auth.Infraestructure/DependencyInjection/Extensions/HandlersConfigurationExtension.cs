using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Configuration;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions
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
