namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Contracts;

public class GetOrdersPagedResponse
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = default!;
    public decimal Total { get; set; }
}
