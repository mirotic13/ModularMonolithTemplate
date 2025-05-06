using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolithTemplate.Inventory.Domain.Entities;

namespace ModularMonolithTemplate.Inventory.Infraestructure.Persistence.Configurations;

public class StockEntryConfiguration : IEntityTypeConfiguration<StockEntry>
{
    public void Configure(EntityTypeBuilder<StockEntry> builder)
    {
        builder.ToTable("StockEntries");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.ProductId)
               .IsRequired();

        builder.Property(s => s.Quantity)
               .IsRequired();

        builder.Property(s => s.Type)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(s => s.CreatedAt)
               .IsRequired();

        builder.HasOne<Product>()
               .WithMany()
               .HasForeignKey(s => s.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
