using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using Serilog;

namespace ModularMonolithTemplate.BuildingBlocks.Http;

public static class HttpResponseMapper
{
    public static IActionResult ToActionResult<T>(this BaseResponse<T> response)
    {
        if (response == null)
        {
            Log.Error("BaseResponse was null");
            return new StatusCodeResult(500);
        }

        if (!response.Success)
        {
            Log.Warning("Failed response: {Message} | Errors: {@Errors}", response.Message, response.Errors);

            if (response.ValidationErrors != null && response.ValidationErrors.Any())
                return new BadRequestObjectResult(response);

            if (response.Errors?.Any(e => e == "VALIDATION_ERROR") == true)
                return new BadRequestObjectResult(response);

            if (response.Errors?.Any(e => e == "DOMAIN_ERROR") == true)
                return new UnprocessableEntityObjectResult(response);

            return new BadRequestObjectResult(response);
        }

        if (response.Data is false)
            return new UnauthorizedObjectResult(response);

        if (response.Data is null)
            return new NotFoundObjectResult(response);

        return new OkObjectResult(response);
    }

    public static IActionResult ToActionResultPaged<T>(this PagedResponse<T> response)
    {
        if (response == null)
        {
            Log.Error("PagedResponse was null");
            return new StatusCodeResult(500);
        }

        if (!response.Success)
        {
            Log.Warning("PagedResponse failed: {Message}. Errors: {@Errors}", response.Message, response.Errors);

            if (response.ValidationErrors != null && response.ValidationErrors.Any())
                return new BadRequestObjectResult(response);

            if (response.Errors?.Contains("VALIDATION_ERROR") == true)
                return new BadRequestObjectResult(response);

            if (response.Errors?.Contains("DOMAIN_ERROR") == true)
                return new UnprocessableEntityObjectResult(response);

            return new BadRequestObjectResult(response);
        }

        if (response.Data == null || response.Data.Count == 0)
        {
            Log.Information("PagedResponse returned empty list: {Message}", response.Message);
            return new NotFoundObjectResult(response);
        }

        return new OkObjectResult(response);
    }
}
