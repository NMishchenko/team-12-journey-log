using System.Linq.Expressions;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class BaseRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : BaseEntity<TId>
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(JourneyLogContext journeyLogContext)
    {
        _context = journeyLogContext;
        _dbSet = _context.Set<TEntity>();
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.Entity;
    }

    public async virtual Task DeleteByIdAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async virtual Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
    {
        var entities = _dbSet.Where(filter);
        return await entities.ToListAsync();
    }

    public async virtual Task<TEntity?> GetByIdAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async virtual Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<bool> CheckIfEntityExistsById(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity is not null;
    }
}