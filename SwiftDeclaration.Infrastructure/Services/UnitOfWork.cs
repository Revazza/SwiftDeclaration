using SwiftDeclaration.Infrastructure.Services.Interfaces;
using SwiftDeclaration.Persistance.Context;

namespace SwiftDeclaration.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly SwiftDeclarationDbContext _context;

    public UnitOfWork(SwiftDeclarationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
