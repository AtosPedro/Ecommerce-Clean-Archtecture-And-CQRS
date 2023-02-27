using Ecommerce.Application.Common.Interfaces;
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
        protected readonly ISyncService SyncService;

        protected Repository(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext, 
            ISyncService syncService)
        {
            WriteContext = writeContext;
            ReadContext = readContext;
            WriteDbSet = writeContext.Set<TEntity>();
            ReadDbSet = readContext.Set<TEntity>();
            SyncService = syncService;
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            SyncService.SyncWriteAndReadDBs();
            return await ReadDbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(int id, CancellationToken cancellationToken)
        {
            SyncService.SyncWriteAndReadDBs();
            return await ReadDbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            SyncService.SyncWriteAndReadDBs();
            return await ReadDbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken)
        {
            SyncService.SyncWriteAndReadDBs();
            await WriteDbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            SyncService.SyncWriteAndReadDBs();
            await Task.FromResult(WriteDbSet.Update(entity));
            return entity;
        }

        public virtual async Task<TEntity> Remove(TEntity entity)
        {
            SyncService.SyncWriteAndReadDBs();
            await Task.FromResult(WriteDbSet.Remove(entity));
            return entity;
        }
    }
}
