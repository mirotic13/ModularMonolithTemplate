namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Contracts;

public class GetOrdersPagedRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
