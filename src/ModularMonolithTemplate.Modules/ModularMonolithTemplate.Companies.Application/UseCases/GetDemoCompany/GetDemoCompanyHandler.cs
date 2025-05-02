using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Companies.Application.UseCases.GetDemoCompany;

public class GetDemoCompanyHandler : IRequestHandler<GetDemoCompanyQuery, BaseResponse<GetDemoCompanyResponse>>
{
    public Task<BaseResponse<GetDemoCompanyResponse>> Handle(GetDemoCompanyQuery request, CancellationToken cancellationToken)
    {
        var response = new GetDemoCompanyResponse(Guid.NewGuid(), "Widenex Corporation");
        return Task.FromResult(BaseResponse<GetDemoCompanyResponse>.Ok(response));
    }
}
