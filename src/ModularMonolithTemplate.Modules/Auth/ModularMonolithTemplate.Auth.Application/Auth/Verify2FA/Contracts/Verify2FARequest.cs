namespace ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Contracts;

public class Verify2FARequest
{
    public string Email { get; set; } = default!;
    public string Code { get; set; } = default!;
}
