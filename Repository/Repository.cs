using System.Linq.Expressions;
using Livraria.Data;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}