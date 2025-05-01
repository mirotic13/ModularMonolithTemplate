using MediatR;

namespace ModularMonolithTemplate.Companies.Application.GetDemoCompany;

public class GetDemoCompanyHandler : IRequestHandler<GetDemoCompanyQuery, GetDemoCompanyResponse>
{
    public Task<GetDemoCompanyResponse> Handle(GetDemoCompanyQuery request, CancellationToken cancellationToken)
    {
        var response = new GetDemoCompanyResponse(Guid.NewGuid(), "Widenex Corporation");
        return Task.FromResult(response);
    }
}
