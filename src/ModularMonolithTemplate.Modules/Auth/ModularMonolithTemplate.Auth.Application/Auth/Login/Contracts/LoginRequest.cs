namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;

public class LoginRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
