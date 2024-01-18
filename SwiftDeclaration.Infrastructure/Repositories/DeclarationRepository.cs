using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Persistance.Context;

namespace SwiftDeclaration.Infrastructure.Repositories;

public class DeclarationRepository : BaseRepository<Declaration, int>, IDeclarationRepository
{
    public DeclarationRepository(SwiftDeclarationDbContext context) : base(context)
    {
    }
}
