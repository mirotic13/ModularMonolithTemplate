using ModularMonolithTemplate.SharedKernel.Domain;

namespace ModularMonolithTemplate.Auth.Domain.Entities;

public class RevokedToken(string jti, Guid userId, DateTime? expiration) : BaseEntity
{
    public string Jti { get; private set; } = jti;
    public Guid UserId { get; private set; } = userId;
    public DateTime RevokedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? Expiration { get; private set; } = expiration;
}
