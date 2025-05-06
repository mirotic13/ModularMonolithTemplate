using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolithTemplate.Sales.Domain.Entities;

namespace ModularMonolithTemplate.Sales.Infraestructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.CreatedAt)
               .IsRequired();

        builder.HasMany(o => o.Items)
               .WithOne()
               .HasForeignKey("OrderId");

        builder.Navigation(o => o.Items).AutoInclude();

        builder.OwnsMany(o => o.Items, items =>
        {
            items.WithOwner().HasForeignKey("OrderId");
            items.ToTable("OrderItems");
            items.Property<Guid>("Id");
            items.HasKey("Id");

            items.Property(i => i.ProductId).IsRequired();
            items.Property(i => i.Quantity).IsRequired();
            items.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)");
        });

    }
}
