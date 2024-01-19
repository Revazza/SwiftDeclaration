using MediatR;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;

public record GetAllDeclarationsBriefDetailsQuery(string Headline = "")
    : IRequest<List<GetAllDeclarationsBriefDetailsQueryResponse>>, ICacheableQuery
{
    public string SectionName => "GetAllDeclarationsBriefDetails";

    public string Salt { get; set; } = Headline;
}
