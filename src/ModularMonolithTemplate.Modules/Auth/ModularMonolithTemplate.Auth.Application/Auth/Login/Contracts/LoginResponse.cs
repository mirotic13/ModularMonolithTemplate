namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;

public class LoginResponse
{
    public string Token { get; set; } = default!;
    public bool TwoFactorEnabled { get; set; }
    public string UserName { get; set; } = default!;
    public List<string> Roles { get; set; } = [];
    public string? RefreshToken { get; set; }
}
