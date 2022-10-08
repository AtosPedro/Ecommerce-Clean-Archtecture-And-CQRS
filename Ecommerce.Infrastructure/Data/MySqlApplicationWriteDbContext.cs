using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class MySqlApplicationWriteDbContext : DbContext, IApplicationWriteDbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<OperationalUnit> OperationalUnit { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DatabaseFacade Database { get; set; }

        protected readonly IConfiguration _configuration;
        protected readonly IIdentityService _identityService;
        private readonly CurrentUser _currentUser;

        public MySqlApplicationWriteDbContext(
            IConfiguration configuration,
            IIdentityService identityService)
        {
            _configuration = configuration;
            _identityService = identityService;
            _currentUser = identityService.GetCurrent();
            Database = base.Database;
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUser.Email;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UptatedBy = _currentUser.Email;
                        entry.Entity.UptatedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override void Dispose() => base.Dispose();

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = "";
            if (Environment.GetEnvironmentVariable("CONTAINER") == "true")
            {
                connectionString = _configuration.GetConnectionString("WriteDatabase");
            }
            else
            {
                connectionString = _configuration.GetConnectionString("LocalWriteDatabase");
            }
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().Ignore(n => n.Guid);
            builder.Entity<OperationalUnit>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.StoreGuid);
            builder.Entity<User>().Ignore(n => n.Guid);
            builder.Entity<Supplier>().Ignore(n => n.Guid);
            builder.Entity<Material>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.StoreGuid)
                .Ignore(n => n.SupplierGuid);
            builder.Entity<Operation>()
                .Ignore(n => n.Guid)
                .Ignore(n => n.StoreGuid)
                .Ignore(n => n.MaterialGuid)
                .Ignore(n => n.OperationalUnitGuid);
        }
    }
}
