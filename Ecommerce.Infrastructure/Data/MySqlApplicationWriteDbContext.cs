using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Extensions;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class MySqlApplicationWriteDbContext : DbContext, IApplicationWriteDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
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
            builder.IgnoreGuids();
        }
    }
}
