using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Infrastructure.Persistence;

public static class InventoryDbInitializer
{
    public static async Task InitializeAsync(InventoryDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.StockItems.Any())
        {
            var stock = new List<StockItem>
        {
            new StockItem(Guid.NewGuid(), 20),
            new StockItem(Guid.NewGuid(), 10),
            new StockItem(Guid.NewGuid(), 0)
        };

            context.StockItems.AddRange(stock);
            await context.SaveChangesAsync();
        }
    }
}