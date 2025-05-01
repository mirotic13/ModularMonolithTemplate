using MediatR;

namespace ModularMonolithTemplate.Users.Application.GetDemoUser;

public record GetDemoUserQuery : IRequest<GetDemoUserResponse>;

