using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

public record GetDemoUserValidationErrorQuery : IRequest<BaseResponse<GetDemoUserValidationErrorResponse>>;
