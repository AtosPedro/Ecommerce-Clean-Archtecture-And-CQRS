using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class MySqlApplicationReadDbContext : DbContext, IApplicationReadDbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<OperationalUnit> OperationalUnit { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected readonly IConfiguration _configuration;
        protected readonly IIdentityService _identityService;

        public MySqlApplicationReadDbContext(
            IConfiguration configuration,
            IIdentityService identityService)
        {
            _configuration = configuration;
            _identityService = identityService;
        }

        public override void Dispose() => base.Dispose();

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("ReadDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().Ignore(n => n.Guid);
            builder.Entity<OperationalUnit>().Ignore(n => n.Guid);
            builder.Entity<User>().Ignore(n => n.Guid);
            builder.Entity<Supplier>().Ignore(n => n.Guid);
            builder.Entity<Material>().Ignore(n => n.Guid);
            builder.Entity<Operation>().Ignore(n => n.Guid);
        }
    }
}
