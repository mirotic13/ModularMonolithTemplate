using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Validations;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Validators;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Validators;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtension
{
    public static IServiceCollection ConfigureValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<RegisterRequestValidator>()
            .AddValidatorsFromAssemblyContaining<LoginRequestValidator>()
            .AddValidatorsFromAssemblyContaining<RefreshTokenRequestValidator>();

        return services;
    }
}
