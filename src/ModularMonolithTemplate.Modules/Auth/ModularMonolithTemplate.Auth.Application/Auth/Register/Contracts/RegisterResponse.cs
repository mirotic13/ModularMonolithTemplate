namespace ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;

public class RegisterResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool TwoFactorEnabled { get; set; }
}
