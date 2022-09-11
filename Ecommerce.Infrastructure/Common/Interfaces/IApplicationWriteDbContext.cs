using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface IApplicationWriteDbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<OperationalUnit> OperationalUnit { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Operation> Operations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity ;
    }
}
