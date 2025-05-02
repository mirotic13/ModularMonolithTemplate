using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Companies.Application.UseCases.GetDemoCompany;

public record GetDemoCompanyQuery : IRequest<BaseResponse<GetDemoCompanyResponse>>;
