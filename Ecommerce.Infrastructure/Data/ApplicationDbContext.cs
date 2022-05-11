using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "";
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UptatedBy = "";
                        entry.Entity.UptatedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override void Dispose() => base.Dispose();

        public override DbSet<TEntity> Set<TEntity>() => base.Set<TEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = _configuration.GetConnectionString("WebDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
