namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;

public class RefreshTokenResponse
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
