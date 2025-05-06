namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; } = default!;
}
