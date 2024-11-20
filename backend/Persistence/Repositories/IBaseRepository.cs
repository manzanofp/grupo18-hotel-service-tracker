using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public interface IBaseRepository<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    Task<TEntity> SelectAsync(long id);

    Task<ICollection<TEntity>> SelectAsync();

    Task<TEntity> InsertAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);

    TEntity PrepareEntityToUpdate(TEntity oldEntity, TEntity newEntity);
}
