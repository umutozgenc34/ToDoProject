

using Core.Entities;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Core.Repository.Abstracts;

public interface IGenericRepository<TEntity,TId> 
    where TEntity : BaseEntity<TId> , new()
{
    IQueryable<TEntity> GetAll();
    ValueTask<TEntity?> GetByIdAsync(TId id);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    ValueTask AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
