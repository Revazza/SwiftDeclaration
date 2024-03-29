﻿namespace SwiftDeclaration.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T, TId>
    where T : class
{
    Task<T?> AddAsync(T entity);
    IQueryable<T> AsQuery();
    Task<T?> GetByIdAsync(TId id);
    void Update(T entity);
    void Remove(T entity);
}


