namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;

public class LoginDemoRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
