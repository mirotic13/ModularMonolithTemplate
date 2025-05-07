using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace ModularMonolithTemplate.SharedKernel.Logging;

public static class LoggerConfigurationExtensions
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

    public static IServiceCollection AddLogService(this IServiceCollection services)
    {
        return services.AddScoped(typeof(ILogService<>), typeof(LogService<>));
    }
}
