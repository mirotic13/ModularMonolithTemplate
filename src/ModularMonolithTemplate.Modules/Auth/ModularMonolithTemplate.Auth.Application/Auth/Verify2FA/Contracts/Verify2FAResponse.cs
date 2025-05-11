namespace ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Contracts;

public class Verify2FAResponse
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
