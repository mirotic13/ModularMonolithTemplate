using MediatR;

namespace ModularMonolithTemplate.Companies.Application.GetDemoCompany;

public record GetDemoCompanyQuery : IRequest<GetDemoCompanyResponse>;

