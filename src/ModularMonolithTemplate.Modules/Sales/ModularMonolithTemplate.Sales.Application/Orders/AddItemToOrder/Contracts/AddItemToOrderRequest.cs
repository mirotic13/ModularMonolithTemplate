namespace ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Contracts;

public class AddItemToOrderRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}