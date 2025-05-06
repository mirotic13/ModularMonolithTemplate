using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Contracts;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;

public class IsAuthenticatedDemoQueryHandler(IHttpContextAccessor httpContextAccessor) : IRequestHandler<IsAuthenticatedDemoQuery, IsAuthenticatedDemoResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Task<IsAuthenticatedDemoResponse> Handle(IsAuthenticatedDemoQuery request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        var email = user?.FindFirst(ClaimTypes.Name)?.Value;

        return Task.FromResult(new IsAuthenticatedDemoResponse
        {
            Email = email
        });
    }
}
