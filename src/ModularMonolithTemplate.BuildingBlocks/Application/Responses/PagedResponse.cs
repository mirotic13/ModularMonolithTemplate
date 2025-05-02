namespace ModularMonolithTemplate.BuildingBlocks.Application.Responses;

public class PagedResponse<T> : BaseResponse<List<T>>
{
    public int TotalCount { get; init; }
    public int PageSize { get; init; }
    public int CurrentPage { get; init; }

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
}
