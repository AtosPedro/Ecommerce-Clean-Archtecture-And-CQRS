﻿using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Repositories
{
    public abstract class RepositoryMySqlDb<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationMySqlDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected RepositoryMySqlDb(ApplicationMySqlDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
