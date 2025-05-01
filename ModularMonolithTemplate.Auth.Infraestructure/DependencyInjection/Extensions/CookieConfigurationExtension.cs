using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class CookieConfigurationExtension
{
    public static IServiceCollection ConfigureCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Events.OnRedirectToLogin = context =>
            {
                if (context.Request.Path.StartsWithSegments("/api"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var response = "{\"message\": \"You are not authorized to access this resource.\"}";
                    return context.Response.WriteAsync(response);
                }

                context.Response.Redirect(context.RedirectUri);
                return Task.CompletedTask;
            };
        });

        return services;
    }
}
