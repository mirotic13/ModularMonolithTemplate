using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Diagnostics;

namespace ModularMonolithTemplate.SharedKernel.Middleware;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        var correlationId = context.TraceIdentifier;

        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            context.Response.Headers["X-Correlation-Id"] = correlationId;

            _logger.LogInformation("HTTP {Method} {Path} requested", context.Request.Method, context.Request.Path);

            await _next(context);

            sw.Stop();

            _logger.LogInformation("HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs} ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                sw.ElapsedMilliseconds);
        }
    }
}
