using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ModularMonolithTemplate.SharedKernel.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = context.TraceIdentifier;
        context.Response.Headers["X-Correlation-Id"] = traceId;

        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "[{TraceId}] Unauthorized: {Message}", traceId, ex.Message);
            await WriteProblemDetails(context, StatusCodes.Status401Unauthorized, "Unauthorized", ex.Message, traceId);
        }
        catch (ValidationException ex)
        {
            var detail = string.Join(" | ", ex.Errors.Select(e => e.ErrorMessage));
            _logger.LogWarning(ex, "[{TraceId}] Validation failed: {Message}", traceId, detail);
            await WriteProblemDetails(context, StatusCodes.Status400BadRequest, "Validation Error", detail, traceId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[{TraceId}] Unhandled exception: {Message}", traceId, ex.Message);
            await WriteProblemDetails(context, StatusCodes.Status500InternalServerError, "Internal Server Error", "An unexpected error occurred.", traceId);
        }
    }

    private static async Task WriteProblemDetails(HttpContext context, int statusCode, string title, string detail, string traceId)
    {
        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path,
            Extensions = { ["traceId"] = traceId }
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(problem);
    }
}
