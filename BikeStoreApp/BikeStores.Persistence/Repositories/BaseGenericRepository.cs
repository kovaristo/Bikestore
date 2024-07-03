using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Persistence.Repositories
{
    public abstract class BaseGenericRepository<TEntity, TKey> : BaseGenericRepository<TEntity> where TEntity: class
    {
        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> FindByKey(TKey key, CancellationToken cancellationToken)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(key);
        }
    }

    public abstract class BaseGenericRepository<TEntity, TKey1, TKey2> : BaseGenericRepository<TEntity> where TEntity : class
    {
        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> FindByKey(TKey1 key1, TKey2 key2, CancellationToken cancellationToken)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(key1, key2);
        }
    }

    public abstract class BaseGenericRepository<TEntity, TKey1, TKey2, TKey3> : BaseGenericRepository<TEntity> where TEntity : class
    {
        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> FindByKey(TKey1 key1, TKey2 key2, TKey3 key3, CancellationToken cancellationToken)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(key1, key2, key3);
        }
    }

    public abstract class BaseGenericRepository<TEntity, TKey1, TKey2, TKey3, TKey4> : BaseGenericRepository<TEntity> where TEntity : class
    {
        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> FindByKey(TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, CancellationToken cancellationToken)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(key1, key2, key3, key4);
        }
    }

    public abstract class BaseGenericRepository<TEntity, TKey1, TKey2, TKey3, TKey4, TKey5> : BaseGenericRepository<TEntity> where TEntity : class
    {
        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> FindByKey(TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5, CancellationToken cancellationToken)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(key1, key2, key3, key4, key5);
        }
    }

    public abstract class BaseGenericRepository<TEntity> : BaseRepository where TEntity : class
    {
        const int MAX_ALL_RECORDS = 50;

        public BaseGenericRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.DbContext.Entry<TEntity>(entity).State = EntityState.Added;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.DbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }
    }
}
