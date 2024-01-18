using Microsoft.EntityFrameworkCore;
using SwiftDeclaration.Persistance.Context;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;

namespace SwiftDeclaration.Infrastructure.Repositories;

public class BaseRepository<T, TId> : IBaseRepository<T, TId>
    where T : class
{
    protected readonly SwiftDeclarationDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(SwiftDeclarationDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task<T?> AddAsync(T entity)
    {
        return (await _entities.AddAsync(entity)).Entity;
    }

    public virtual void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public IQueryable<T> AsQuery()
    {
        return _entities.AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(TId id)
    {
        return await _entities.FindAsync(id);
    }

    public virtual void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

}
