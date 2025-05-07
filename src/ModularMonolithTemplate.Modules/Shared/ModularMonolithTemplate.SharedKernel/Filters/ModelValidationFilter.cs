using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ModularMonolithTemplate.SharedKernel.Filters;

public class ModelValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var problemDetails = new ValidationProblemDetails(errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Model validation failed",
                Instance = context.HttpContext.Request.Path
            };

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status,
                ContentTypes = { "application/problem+json" }
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
