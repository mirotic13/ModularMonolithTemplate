using Microsoft.AspNetCore.Identity;

namespace ModularMonolithTemplate.Auth.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
