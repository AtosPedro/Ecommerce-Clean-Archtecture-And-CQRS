using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationMySqlDbContext : DbContext
    {

        protected readonly IConfiguration _configuration;

        public ApplicationMySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = _configuration.GetConnectionString("WebDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
