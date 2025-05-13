using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Sales.Domain.Entities;

namespace ModularMonolithTemplate.Sales.Infrastructure.Persistence;

public static class SalesDbInitializer
{
    public static async Task InitializeAsync(SalesDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Orders.Any())
        {
            var customer1 = Guid.NewGuid();
            var customer2 = Guid.NewGuid();

            var order1 = new Order(customer1);
            order1.AddItem(new OrderItem(Guid.NewGuid(), 2, 15.99m));
            order1.AddItem(new OrderItem(Guid.NewGuid(), 1, 89.50m));

            var order2 = new Order(customer2);
            order2.AddItem(new OrderItem(Guid.NewGuid(), 3, 7.25m));

            context.Orders.AddRange(order1, order2);
            await context.SaveChangesAsync();
        }
    }
}
