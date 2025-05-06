namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;

public class LoginDemoResponse
{
    public string Token { get; set; } = default!;
    public string Message { get; set; } = "Login demo successful";
}
