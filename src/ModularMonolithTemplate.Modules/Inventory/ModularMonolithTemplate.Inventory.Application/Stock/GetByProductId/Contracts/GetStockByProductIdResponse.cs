namespace ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Contracts;

public class GetStockByProductIdResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
