using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Application.Abstractions;

public interface IInventoryDbContext
{
    DbSet<StockItem> StockItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}