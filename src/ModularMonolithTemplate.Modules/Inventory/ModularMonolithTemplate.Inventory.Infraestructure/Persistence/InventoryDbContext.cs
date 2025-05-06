using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Inventory.Domain.Entities;
using ModularMonolithTemplate.Inventory.Infraestructure.Persistence.Configurations;

namespace ModularMonolithTemplate.Inventory.Infraestructure.Persistence;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<StockEntry> StockEntries => Set<StockEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new StockEntryConfiguration());
    }
}
