using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext DbContext { get; set; }

        private DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

        public GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException();
        }

        public async Task Create(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(); }
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(); }
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(); }
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(string.Concat(ex.Message, "Save Errors:", string.Join(";", ex)));
            }
        }


        public Task<TEntity> ReadBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public Task<IQueryable<TEntity>> ReadListBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() => DbSet.AsNoTracking().Where(predicate).AsQueryable());
        }

        public Task<IQueryable<TEntity>> ReadAll()
        {
            return Task.Run(() => DbSet.AsNoTracking().AsQueryable());
        }

        public Task<IQueryable<TEntity>> Skip(int count)
        {
            return Task.Run(() => DbSet.AsNoTracking().Skip(count));
        }

        public Task<IQueryable<TEntity>> Take(int count)
        {
            return Task.Run(() => DbSet.AsNoTracking().Take(count));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DbContext != null)
                {
                    this.DbContext.Dispose();
                    this.DbContext = null;
                }
            }
        }

    }
}

