using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;

public class GetAllDeclarationsBriefDetailsQueryHandler
    : IRequestHandler<GetAllDeclarationsBriefDetailsQuery, List<GetAllDeclarationsBriefDetailsQueryResponse>>
{
    private readonly IDeclarationRepository _declarationRepository;

    public GetAllDeclarationsBriefDetailsQueryHandler(IDeclarationRepository declarationRepository)
    {
        _declarationRepository = declarationRepository;
    }

    public async Task<List<GetAllDeclarationsBriefDetailsQueryResponse>> Handle(
        GetAllDeclarationsBriefDetailsQuery request, CancellationToken cancellationToken)
    {
        var query = _declarationRepository
            .AsQuery()
            .AsNoTracking();

        query = ApplyFilters(query, request);

        return await query
            .ProjectToType<GetAllDeclarationsBriefDetailsQueryResponse>()
            .ToListAsync(cancellationToken);
    }

    private static IQueryable<Declaration> ApplyFilters(
        IQueryable<Declaration> query,
        GetAllDeclarationsBriefDetailsQuery request)
    {
        query = FilterByHeadline(query, request.Headline);
        return query;
    }

    private static IQueryable<Declaration> FilterByHeadline(IQueryable<Declaration> query, string headLine)
        => string.IsNullOrEmpty(headLine) ? query : query.Where(x => x.HeadLine.StartsWith(headLine));

}
