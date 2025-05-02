using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.UseCases.Register;
using ModularMonolithTemplate.BuildingBlocks.Application.Behaviors;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtension
{
    public static IServiceCollection ConfigureValidation(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddModuleValidations<RegisterCommandValidator>();

        return services;
    }
}
