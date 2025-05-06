using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithTemplate.BuildingBlocks.DependencyInjection
{
    public static class ValidationModuleExtensions
    {
        public static IServiceCollection AddModuleValidations<T>(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<T>();
            return services;
        }
    }
}
