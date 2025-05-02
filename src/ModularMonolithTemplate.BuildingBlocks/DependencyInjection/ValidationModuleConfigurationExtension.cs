using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Application.Behaviors;

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
