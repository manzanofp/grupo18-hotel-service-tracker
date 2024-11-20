using Application.Repositories;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext _context;

    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(TContext context, DbSet<TEntity> dbSet)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public Task<TEntity> DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        if (entity is null)
            throw new ArgumentException("Entity is invalid.", nameof(entity));

        entity.CreatedAt = DateTime.UtcNow;
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public TEntity PrepareEntityToUpdate(TEntity oldEntity, TEntity entity)
    {
        _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        return oldEntity;
    }

    public async Task<TEntity> SelectAsync(long id)
    {
        return await _dbSet.Where(x => !x.DeleteAt.HasValue).SingleOrDefaultAsync(p => p.Id == id);
    }

    public  async Task<ICollection<TEntity>> SelectAsync()
    {
        return await _dbSet.Where(x => !x.DeleteAt.HasValue).ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var oldEntity = SelectAsync(entity.Id).Result ?? throw new Exception("Entity not found");

        entity.UpdatedAt = DateTime.UtcNow;
        entity.CreatedAt = oldEntity.CreatedAt;

        PrepareEntityToUpdate(oldEntity, entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}
