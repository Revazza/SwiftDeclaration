using MediatR;

namespace SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;

public record GetAllDeclarationsBriefDetailsQuery(string Headline = "")
    : IRequest<List<GetAllDeclarationsBriefDetailsQueryResponse>>;
