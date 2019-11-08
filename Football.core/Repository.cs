using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Football.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Football.core
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(FootballContext context)
        {
            this.context = context;

            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        public virtual EntityState Add(T entity)
        {
            return this.dbSet.Add(entity).State;
        }

        public virtual async Task AddAsync(T entity)
        {
             var record= await this.dbSet.AddAsync(entity);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
        }
        public virtual async Task UpdateAsync(T entity)
        {
            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
        }
        public T Get<TKey>(TKey id)
        {
            return this.dbSet.Find(id);
        }

        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public T Get(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }


        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return this.FindBy(predicate).Include(include);
        }

        
        public EntityState Delete(T entity)
        {
            return this.dbSet.Remove(entity).State;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Any(predicate);
        }

        public virtual EntityState Update(T entity)
        {
            return this.dbSet.Update(entity).State;
        }
    }
}
