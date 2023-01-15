using System.Linq.Expressions;

namespace Livraria.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}