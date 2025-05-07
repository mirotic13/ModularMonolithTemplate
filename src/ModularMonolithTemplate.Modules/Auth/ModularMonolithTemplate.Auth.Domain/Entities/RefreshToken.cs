using ModularMonolithTemplate.SharedKernel.Domain.Entities;

namespace ModularMonolithTemplate.Auth.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; private set; } = false;

    public void Revoke() => Revoked = true;
}
