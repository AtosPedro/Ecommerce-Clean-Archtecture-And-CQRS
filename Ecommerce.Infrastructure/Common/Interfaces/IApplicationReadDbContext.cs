using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface IApplicationReadDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DatabaseFacade Database { get; set; }
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
