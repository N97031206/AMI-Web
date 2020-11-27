using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task SaveChanges();

        Task<TEntity> ReadBy(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TEntity>> ReadListBy(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TEntity>> ReadAll();

        Task<IQueryable<TEntity>> Skip(int count);

        Task<IQueryable<TEntity>> Take(int count);


    }
}
