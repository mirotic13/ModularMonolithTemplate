using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Register;

public record RegisterCommand(string Email, string Password, string FullName) : IRequest<BaseResponse<bool>>;
