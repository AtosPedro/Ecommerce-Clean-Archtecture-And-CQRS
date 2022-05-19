using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Common.Interfaces;
using Ecommerce.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class MySqlApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected readonly IConfiguration _configuration;
        protected readonly IUserService _userService;
        private readonly CurrentUser _currentUser;

        public MySqlApplicationDbContext(
            IConfiguration configuration,
            IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
            _currentUser = userService.GetCurrent();
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
            // connect to mysql with connection string from app settings
            var connectionString = _configuration.GetConnectionString("WebDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
