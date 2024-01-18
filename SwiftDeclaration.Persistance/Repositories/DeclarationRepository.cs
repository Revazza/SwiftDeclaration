using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Persistance.Context;
using SwiftDeclaration.Persistance.Repositories.Interfaces;

namespace SwiftDeclaration.Persistance.Repositories;

public class DeclarationRepository : BaseRepository<Declaration, int>, IDeclarationRepository
{
    public DeclarationRepository(SwiftDeclarationDbContext context) : base(context)
    {
    }
}
