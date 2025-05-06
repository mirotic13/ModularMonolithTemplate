using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;

public class LoginDemoCommandHandler : IRequestHandler<LoginDemoCommand, LoginDemoResponse>
{
    private readonly IConfiguration _configuration;

    public LoginDemoCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<LoginDemoResponse> Handle(LoginDemoCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, request.Email),
            new("demo", "true")
        };

        var jwtSection = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSection["Issuer"],
            audience: jwtSection["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return Task.FromResult(new LoginDemoResponse
        {
            Token = tokenStr
        });
    }
}
