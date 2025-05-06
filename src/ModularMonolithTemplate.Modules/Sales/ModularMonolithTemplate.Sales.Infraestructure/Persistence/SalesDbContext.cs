using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Domain.Entities;
using ModularMonolithTemplate.Sales.Infraestructure.Persistence.Configurations;

namespace ModularMonolithTemplate.Sales.Infraestructure.Persistence;

public class SalesDbContext(DbContextOptions<SalesDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
