using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Companies.Application.Configuration;

namespace ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection.Extensions
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
