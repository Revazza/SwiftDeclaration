namespace SwiftDeclaration.Infrastructure.Services.Interfaces;
public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
