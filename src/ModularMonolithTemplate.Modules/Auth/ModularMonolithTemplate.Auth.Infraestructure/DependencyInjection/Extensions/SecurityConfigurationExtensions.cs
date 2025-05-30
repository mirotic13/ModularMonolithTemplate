﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Security;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class SecurityConfigurationExtensions
{
    public static IServiceCollection ConfigureSecurity(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, RequireValidTokenHandler>();
        services.AddAuthorizationBuilder()
            .AddPolicy("ValidTokenOnly", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.AddRequirements(new RequireValidToken());
            });

        return services;
    }
}
