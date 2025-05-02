using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;

public record GetDemoUserDomainErrorQuery : IRequest<BaseResponse<DemoUserDomainErrorResponse>>;
