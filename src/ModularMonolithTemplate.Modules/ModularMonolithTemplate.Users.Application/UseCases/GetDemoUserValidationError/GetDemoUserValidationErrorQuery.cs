using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

public record GetDemoUserValidationErrorQuery : IRequest<BaseResponse<DemoUserValidationErrorResponse>>;
