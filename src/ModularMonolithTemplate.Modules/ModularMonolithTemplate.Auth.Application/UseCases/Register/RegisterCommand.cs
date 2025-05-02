using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Requests;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Register;

public record RegisterCommand(RegisterRequest Request) : IRequest<BaseResponse<bool>>;
