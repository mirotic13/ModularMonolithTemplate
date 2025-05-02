using ModularMonolithTemplate.BuildingBlocks.Application.Errors;

namespace ModularMonolithTemplate.BuildingBlocks.Application.Responses;

public class BaseResponse<T>
{
    public bool Success { get; init; }
    public string? Message { get; init; }
    public T? Data { get; init; }
    public List<string>? Errors { get; init; }
    public Dictionary<string, List<string>>? ValidationErrors { get; init; }

    public static BaseResponse<T> Ok(T data, string? message = null) => new()
    {
        Success = true,
        Data = data,
        Message = message
    };

    public static BaseResponse<T> Fail(string message, List<string>? errors = null) => new()
    {
        Success = false,
        Message = message,
        Errors = errors
    };

    public static BaseResponse<T> Fail(Error error) => new()
    {
        Success = false,
        Message = error.Message,
        Errors = [error.Code]
    };

    public static BaseResponse<T> Fail(Dictionary<string, List<string>> validationErrors) => new()
    {
        Success = false,
        Message = "Validation failed",
        Errors = ["VALIDATION_ERROR"],
        ValidationErrors = validationErrors
    };
}

