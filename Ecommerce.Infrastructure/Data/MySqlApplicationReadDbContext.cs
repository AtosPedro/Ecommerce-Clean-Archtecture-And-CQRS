using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class MySqlApplicationReadDbContext : DbContext, IApplicationReadDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DatabaseFacade Database { get; set; }

        protected readonly IConfiguration _configuration;
        protected readonly IIdentityService _identityService;

        public MySqlApplicationReadDbContext(
            IConfiguration configuration,
            IIdentityService identityService)
        {
            _configuration = configuration;
            _identityService = identityService;
            Database = base.Database;
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
            builder.Entity<User>().Ignore(n => n.Guid);
            builder.Entity<Product>().Ignore(n => n.Guid);
        }
    }
}
