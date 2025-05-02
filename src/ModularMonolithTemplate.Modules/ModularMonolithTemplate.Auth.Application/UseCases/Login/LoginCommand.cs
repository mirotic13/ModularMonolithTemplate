using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Login;

public record LoginCommand(string Email, string Password) : IRequest<BaseResponse<bool>>;
