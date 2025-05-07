namespace ModularMonolithTemplate.SharedKernel.Application.Responses;

public class PagedResult<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<T>? Data { get; }
    public Error Error { get; }

    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalCount / PageSize);

    private PagedResult(bool isSuccess, List<T>? data, Error error, int page, int pageSize, int totalCount)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static PagedResult<T> Success(List<T> data, int page, int pageSize, int totalCount)
        => new(true, data, Error.None, page, pageSize, totalCount);

    public static PagedResult<T> Failure(Error error)
        => new(false, null, error, 0, 0, 0);
}
