

using Core.Entities;
using Core.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Core.Repository.Concretes;

public abstract class EfGenericRepository<TContext, TEntity, TId> (TContext context) : IGenericRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>, new()
    where TContext : DbContext
{
    protected TContext Context { get; } = context;

    public IQueryable<TEntity> GetAll() => Context.Set<TEntity>().AsNoTracking();

    public ValueTask<TEntity?> GetByIdAsync(TId id) => Context.Set<TEntity>().FindAsync(id);

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null) =>
           predicate == null ? Context.Set<TEntity>().AsNoTracking() : Context.Set<TEntity>().Where(predicate).AsNoTracking();

    public async ValueTask AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);
}
