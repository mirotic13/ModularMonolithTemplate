namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Contracts;

public class GetOrdersByCustomerIdResponse
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = default!;
    public decimal Total { get; set; }
}
