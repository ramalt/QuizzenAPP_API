using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Contracts;

public abstract class RepositoryBase<T> where T : class
{
    private readonly QuizzerAppContext _context;

    protected RepositoryBase(QuizzerAppContext context)
    {
        _context = context;
    }

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().AsQueryable().Where(expression);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public virtual IQueryable<T> Queriable() => _context.Set<T>().AsQueryable();

}
