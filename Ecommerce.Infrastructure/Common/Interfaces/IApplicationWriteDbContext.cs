using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface IApplicationWriteDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity ;
        public DatabaseFacade Database { get; set; }
    }
}
