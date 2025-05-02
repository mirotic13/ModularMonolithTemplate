namespace ModularMonolithTemplate.BuildingBlocks.Application.Responses;

public class PagedResponse<T> : BaseResponse<List<T>>
{
    public int TotalCount { get; init; }
    public int PageSize { get; init; }
    public int CurrentPage { get; init; }
    public Dictionary<string, List<string>>? ValidationErrors { get; init; }

    public static PagedResponse<T> Create(List<T> items, int totalCount, int page, int pageSize, string? message = null)
    {
        return new PagedResponse<T>
        {
            Success = true,
            Data = items,
            TotalCount = totalCount,
            CurrentPage = page,
            PageSize = pageSize,
            Message = message
        };
    }

    public static PagedResponse<T> Fail(Dictionary<string, List<string>> validationErrors)
    {
        return new PagedResponse<T>
        {
            Success = false,
            Message = "Validation failed",
            Errors = new List<string> { "VALIDATION_ERROR" },
            ValidationErrors = validationErrors
        };
    }
}
