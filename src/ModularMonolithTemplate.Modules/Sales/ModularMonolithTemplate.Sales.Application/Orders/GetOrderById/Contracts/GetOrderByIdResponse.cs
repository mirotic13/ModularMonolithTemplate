namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Contracts;

public class GetOrderByIdResponse
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = default!;
    public List<OrderItemDto> Items { get; set; } = [];
}

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}
