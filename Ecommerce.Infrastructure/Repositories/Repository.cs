using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> where TEntity : Entity
    {
        protected readonly IApplicationWriteDbContext WriteContext;
        protected readonly IApplicationReadDbContext ReadContext;
        protected readonly DbSet<TEntity> WriteDbSet;
        protected readonly DbSet<TEntity> ReadDbSet;

        protected Repository(IApplicationWriteDbContext writeContext, IApplicationReadDbContext readContext)
        {
            WriteContext = writeContext;
            ReadContext = readContext;
            WriteDbSet = writeContext.Set<TEntity>();
            ReadDbSet = readContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await ReadDbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await ReadDbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await ReadDbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await WriteDbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            await Task.FromResult(WriteDbSet.Update(entity));
            return entity;
        }

        public virtual async Task<TEntity> Remove(TEntity entity)
        {
            await Task.FromResult(WriteDbSet.Remove(entity));
            return entity;
        }
    }
}
