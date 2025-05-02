using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace ModularMonolithTemplate.BuildingBlocks.Logging;

public static class LoggerConfigurationExtension
{
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        var loggerConfig = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .Filter.ByExcluding(logEvent =>
            logEvent.Properties.TryGetValue("RequestPath", out var path) &&
            path.ToString().Contains("swagger"));

        if (builder.Environment.IsDevelopment())
        {
            loggerConfig.WriteTo.Console(outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] (CorrId: {CorrelationId}) {Message:lj}{NewLine}{Exception}");
        }
        else
        {
            loggerConfig.WriteTo.Console(new CompactJsonFormatter());
        }

        Log.Logger = loggerConfig.CreateLogger();

        builder.Host.UseSerilog();
    }

    public static void UseCustomSerilogExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature?.Error;

                Log.Error(exception, "Unhandled exception");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var message = new { error = "An unexpected error occurred." };
                await context.Response.WriteAsJsonAsync(message);
            });
        });
    }

    public static void UseCustomRequestLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();
    }

    public static IServiceCollection ConfigureLogger(this IServiceCollection services)
    {
        services.AddScoped(typeof(ILogService<>), typeof(LogService<>));
        return services;
    }
}
