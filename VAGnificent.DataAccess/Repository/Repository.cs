using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace VAGnificent.DataAccess.Repository.IRepository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> _dbSet;
    
    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this._dbSet = _db.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = _dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}