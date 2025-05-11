using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Verify2FA.Commands;

public class Verify2FACommand : IRequest<Result<Verify2FAResponse>>
{
    public Verify2FARequest Request { get; set; } = default!;
}
