using Microsoft.AspNetCore.Identity;

namespace ModularMonolithTemplate.Auth.Infraestructure.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
