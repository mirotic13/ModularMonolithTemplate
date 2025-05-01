using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ModularMonolithTemplate.BuildingBlocks.Logging;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        var sw = Stopwatch.StartNew();

        _logger.LogInformation("HTTP {Method} {Path} requested",
            context.Request.Method, context.Request.Path);

        await _next(context);

        sw.Stop();

        _logger.LogInformation("HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs} ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            sw.ElapsedMilliseconds);
    }
}
