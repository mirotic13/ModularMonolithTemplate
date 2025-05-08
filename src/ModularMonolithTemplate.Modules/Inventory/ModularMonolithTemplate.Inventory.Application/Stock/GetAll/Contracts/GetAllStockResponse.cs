namespace ModularMonolithTemplate.Inventory.Application.Stock.GetAll.Contracts;

public class GetAllStockResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
