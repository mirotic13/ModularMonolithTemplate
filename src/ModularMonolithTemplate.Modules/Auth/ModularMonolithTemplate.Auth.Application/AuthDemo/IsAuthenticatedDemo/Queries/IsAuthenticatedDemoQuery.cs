using MediatR;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Contracts;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;

public class IsAuthenticatedDemoQuery : IRequest<IsAuthenticatedDemoResponse>
{
}