using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity ;
    }
}
