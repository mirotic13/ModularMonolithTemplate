using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Diagnostics;

namespace ModularMonolithTemplate.SharedKernel.Filters;

public class ActionTimingFilter : IActionFilter
{
    private readonly ILogger _logger = Log.ForContext<ActionTimingFilter>();
    private readonly Stopwatch _stopwatch = new();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Restart();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();

        var controller = context.ActionDescriptor.RouteValues["controller"];
        var action = context.ActionDescriptor.RouteValues["action"];
        var timeMs = _stopwatch.ElapsedMilliseconds;

        _logger.Information("Action {Controller}/{Action} executed in {Elapsed} ms",
            controller, action, timeMs);
    }
}
