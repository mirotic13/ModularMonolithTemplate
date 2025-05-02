using Microsoft.AspNetCore.Mvc;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using Serilog;

namespace ModularMonolithTemplate.BuildingBlocks.Presentation;

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
            Log.Warning("BaseResponse failed: {Message}. Errors: {@Errors}", response.Message, response.Errors);
            return new BadRequestObjectResult(response);
        }

        if (response.Data is false)
        {
            Log.Information("Request resulted in 'false' boolean: {Message}", response.Message);
            return new UnauthorizedObjectResult(response);
        }

        if (response.Data is null)
        {
            Log.Information("Response data was null: {Message}", response.Message);
            return new NotFoundObjectResult(response);
        }

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
