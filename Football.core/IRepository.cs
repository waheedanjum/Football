using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Football.core
{
 
    public interface IRepository<T>
    {
  
        T Get<TKey>(TKey id);
        Task<T> GetAsync<TKey>(TKey id);

        T Get(params object[] keyValues);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);

        IQueryable<T> GetAll();
      

        EntityState Add(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        EntityState Delete(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
        EntityState Update(T entity);
    }
 
}
