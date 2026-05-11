using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab8_Saul_Nina.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly Linqexample2Context _context;

    public GenericRepository(Linqexample2Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public async Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate, 
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.Where(predicate).ToListAsync();
    }
}