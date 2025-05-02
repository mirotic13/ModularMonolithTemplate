using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUser;

public record GetDemoUserQuery : IRequest<BaseResponse<DemoUserResponse>>;
