using MediatR;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;

public class IsAuthenticatedDemoQuery : IRequest<Result<IsAuthenticatedDemoResponse>>
{
}