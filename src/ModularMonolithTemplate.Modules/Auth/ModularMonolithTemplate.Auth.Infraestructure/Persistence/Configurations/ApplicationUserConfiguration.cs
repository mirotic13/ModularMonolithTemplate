using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolithTemplate.Auth.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Infraestructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        builder.Property(u => u.Email)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(u => u.UserName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.CreatedAt)
               .IsRequired();
    }
}