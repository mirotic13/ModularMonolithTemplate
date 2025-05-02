using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Requests;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Login;

public record LoginCommand(LoginRequest Request) : IRequest<BaseResponse<LoginResponse>>;
