namespace SwiftDeclaration.Persistance.Repositories.Interfaces;

public interface IBaseRepository<T, TId>
    where T : class
{
    Task<T?> AddAsync(T entity);
    IQueryable<T> AsQuery();
    Task<T?> GetByIdAsync(TId id);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}


