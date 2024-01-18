using Microsoft.EntityFrameworkCore;
using SwiftDeclaration.Infrastructure.Services.Interfaces;
using SwiftDeclaration.Persistance.Context;

namespace SwiftDeclaration.Infrastructure.Services;

/// <summary>
/// Represents a unit of work for managing changes and saving updates to the database
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly SwiftDeclarationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class with the specified database context
    /// </summary>
    /// <param name="context">The database context</param>
    public UnitOfWork(SwiftDeclarationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Checks if any changes have been made in the current unit of work
    /// </summary>
    /// <returns><c>true</c> if any changes are detected; otherwise, <c>false</c></returns>
    public bool AnyChanges()
    {
        return _context.ChangeTracker
            .Entries()
            .Where(x =>
                x.State == EntityState.Modified ||
                x.State == EntityState.Added ||
                x.State == EntityState.Deleted)
            .Any();
    }

    /// <summary>
    /// Asynchronously saves changes made in the unit of work to the database
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete</param>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
