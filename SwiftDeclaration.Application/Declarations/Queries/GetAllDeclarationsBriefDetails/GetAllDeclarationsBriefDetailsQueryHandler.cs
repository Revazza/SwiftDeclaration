using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;

public record GetAllDeclarationBriefDetailsQuery() : IRequest<List<GetAllDeclarationsBriefDetailsQueryResponse>>;

public class GetAllDeclarationsBriefDetailsQueryHandler
    : IRequestHandler<GetAllDeclarationBriefDetailsQuery, List<GetAllDeclarationsBriefDetailsQueryResponse>>
{
    private readonly IDeclarationRepository _declarationRepository;

    public GetAllDeclarationsBriefDetailsQueryHandler(IDeclarationRepository declarationRepository)
    {
        _declarationRepository = declarationRepository;
    }

    public async Task<List<GetAllDeclarationsBriefDetailsQueryResponse>> Handle(
        GetAllDeclarationBriefDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _declarationRepository
            .AsQuery()
            .AsNoTracking()
            .ProjectToType<GetAllDeclarationsBriefDetailsQueryResponse>()
            .ToListAsync(cancellationToken);
    }
}
