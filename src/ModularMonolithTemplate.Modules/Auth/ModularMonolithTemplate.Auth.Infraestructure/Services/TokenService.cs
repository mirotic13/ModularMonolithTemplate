using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModularMonolithTemplate.Auth.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Infraestructure.Configuration;

namespace ModularMonolithTemplate.Auth.Infraestructure.Services;

public class TokenService(IOptions<JwtOptions> jwtOptions) : ITokenService
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string GenerateToken(ApplicationUser user, IList<string> roles, bool isTwoFactorAuthenticated)
    {
        var jti = Guid.NewGuid().ToString();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, jti),
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new(ClaimTypes.Name, user.UserName ?? ""),
            new("2fa", isTwoFactorAuthenticated.ToString().ToLower())
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = isTwoFactorAuthenticated ? _jwtOptions.ExpirationMinutes : _jwtOptions.PartialExpirationMinutes;

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiration),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
