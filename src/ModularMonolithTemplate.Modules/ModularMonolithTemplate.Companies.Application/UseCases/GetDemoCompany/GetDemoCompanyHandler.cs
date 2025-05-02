using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Companies.Responses;

namespace ModularMonolithTemplate.Companies.Application.UseCases.GetDemoCompany;

public class GetDemoCompanyHandler : IRequestHandler<GetDemoCompanyQuery, BaseResponse<DemoCompanyResponse>>
{
    public Task<BaseResponse<DemoCompanyResponse>> Handle(GetDemoCompanyQuery query, CancellationToken cancellationToken)
    {
        var response = new DemoCompanyResponse
        {
            Id = Guid.NewGuid(),
            Name = "EmpresaTest"
        };
        return Task.FromResult(BaseResponse<DemoCompanyResponse>.Ok(response));
    }
}
