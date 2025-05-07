using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Validations;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Validators;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Validators;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Validators;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Validators;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Validators;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtension
{
    public static IServiceCollection ConfigureValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<RegisterCommandValidator>()
            .AddValidatorsFromAssemblyContaining<LoginCommandValidator>()
            .AddValidatorsFromAssemblyContaining<LogoutCommandValidator>()
            .AddValidatorsFromAssemblyContaining<RefreshTokenCommandValidator>()
            .AddValidatorsFromAssemblyContaining<IsAuthenticatedDemoQueryValidator>()
            .AddValidatorsFromAssemblyContaining<LoginDemoCommandValidator>();

        return services;
    }
}
