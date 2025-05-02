using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;

public record GetDemoUserDomainErrorQuery : IRequest<BaseResponse<GetDemoUserDomainErrorResponse>>;
