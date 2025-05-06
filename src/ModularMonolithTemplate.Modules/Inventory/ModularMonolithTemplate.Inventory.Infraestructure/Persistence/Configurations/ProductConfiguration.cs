using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolithTemplate.Inventory.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Infraestructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Sku)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Stock)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();
    }
}