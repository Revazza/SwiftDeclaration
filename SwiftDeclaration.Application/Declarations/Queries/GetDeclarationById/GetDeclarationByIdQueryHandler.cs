using MediatR;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Queries.GetDeclarationById;

internal class GetDeclarationByIdQueryHandler : IRequestHandler<GetDeclarationByIdQuery, Declaration?>
{
    private readonly IDeclarationRepository _declarationRepository;

    public GetDeclarationByIdQueryHandler(IDeclarationRepository declarationRepository)
    {
        _declarationRepository = declarationRepository;
    }

    public async Task<Declaration?> Handle(GetDeclarationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _declarationRepository.GetByIdAsync(request.DeclarationId);
    }
}
