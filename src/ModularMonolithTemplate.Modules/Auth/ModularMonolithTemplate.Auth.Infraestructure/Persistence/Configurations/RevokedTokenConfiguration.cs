using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolithTemplate.Auth.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Infraestructure.Persistence.Configurations;

public class RevokedTokenConfiguration : IEntityTypeConfiguration<RevokedToken>
{
    public void Configure(EntityTypeBuilder<RevokedToken> builder)
    {
        builder.ToTable("RevokedTokens");
        builder.HasKey(rt => rt.Id);
        builder.Property(rt => rt.Jti).IsRequired().HasMaxLength(100);
        builder.Property(rt => rt.UserId).IsRequired();
        builder.Property(rt => rt.RevokedAt).IsRequired();
    }
}
