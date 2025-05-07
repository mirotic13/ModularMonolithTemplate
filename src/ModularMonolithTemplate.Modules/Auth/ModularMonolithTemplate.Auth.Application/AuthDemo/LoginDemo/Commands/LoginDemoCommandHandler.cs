using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;

public class LoginDemoCommandHandler(IConfiguration configuration) : IRequestHandler<LoginDemoCommand, Result<LoginDemoResponse>>
{
    private readonly IConfiguration _configuration = configuration;

    public Task<Result<LoginDemoResponse>> Handle(LoginDemoCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, request.Email),
            new("demo", "true")
        };

        var jwtSection = _configuration.GetSection("JwtOptions");
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

        var response = new LoginDemoResponse
        {
            Token = tokenStr
        };

        return Task.FromResult(Result<LoginDemoResponse>.Success(response));
    }
}
