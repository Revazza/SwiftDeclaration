namespace SwiftDeclaration.Infrastructure.Services.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves changes made in the unit of work to the database
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete</param>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if any changes have been made in the current unit of work
    /// </summary>
    /// <returns><c>true</c> if any changes are detected; otherwise, <c>false</c></returns>
    bool AnyChanges();
}
