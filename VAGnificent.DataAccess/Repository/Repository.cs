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

    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                         .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                         .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

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