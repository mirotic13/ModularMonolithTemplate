using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Companies.Responses;

namespace ModularMonolithTemplate.Companies.Application.UseCases.GetDemoCompany;

public record GetDemoCompanyQuery : IRequest<BaseResponse<DemoCompanyResponse>>;
