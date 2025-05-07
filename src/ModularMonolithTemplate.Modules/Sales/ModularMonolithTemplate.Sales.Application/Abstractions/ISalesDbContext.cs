using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Domain.Entities;

namespace ModularMonolithTemplate.Sales.Application.Abstractions;

public interface ISalesDbContext
{
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
