using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUser;

public record GetDemoUserQuery : IRequest<BaseResponse<GetDemoUserResponse>>;
