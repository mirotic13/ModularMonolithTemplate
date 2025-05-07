using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ModularMonolithTemplate.SharedKernel.Application.Responses;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result == null)
        {
            Log.Error("Result was null");
            return new StatusCodeResult(500);
        }

        if (result.IsFailure)
        {
            Log.Warning("Failed Result: {Code} | Message: {Message}", result.Error.Code, result.Error.Message);

            return result.Error.Code switch
            {
                "Validation" => new BadRequestObjectResult(result),
                "Domain" => new UnprocessableEntityObjectResult(result),
                "Unauthorized" => new UnauthorizedObjectResult(result),
                "NotFound" => new NotFoundObjectResult(result),
                _ => new ObjectResult(result) { StatusCode = 500 }
            };
        }

        if (result.Value is false)
            return new UnauthorizedObjectResult(result);

        if (result.Value is null)
            return new NotFoundObjectResult(result);

        return new OkObjectResult(result);
    }

    public static IActionResult ToActionResultPaged<T>(this PagedResult<T> result)
    {
        if (result == null)
        {
            Log.Error("PagedResult was null");
            return new StatusCodeResult(500);
        }

        if (result.IsFailure)
        {
            Log.Warning("Failed PagedResult: {Code} | Message: {Message}", result.Error.Code, result.Error.Message);

            return result.Error.Code switch
            {
                "Validation" => new BadRequestObjectResult(result),
                "Domain" => new UnprocessableEntityObjectResult(result),
                "Unauthorized" => new UnauthorizedObjectResult(result),
                "NotFound" => new NotFoundObjectResult(result),
                _ => new ObjectResult(result) { StatusCode = 500 }
            };
        }

        if (result.Data == null || result.Data.Count == 0)
        {
            Log.Information("PagedResult returned empty list: Page {Page}", result.Page);
            return new NotFoundObjectResult(result);
        }

        return new OkObjectResult(result);
    }
}
