namespace ModularMonolithTemplate.Auth.Infraestructure.Configuration;

public class JwtOptions
{
    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int ExpirationMinutes { get; set; }
    public int PartialExpirationMinutes { get; set; }
}
