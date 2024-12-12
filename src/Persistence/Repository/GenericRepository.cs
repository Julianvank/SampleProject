using Application.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public abstract class GenericRepository<T>(DbSet<T> dbSet) : IRepository<T> where T : class
{
    protected readonly DbSet<T> DbSet = dbSet;
    
    public async Task<T?> GetByIdAsync(object id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void AddRange(IList<T> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Update(T entity)
    {
        DbSet.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
}