using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
        }
    }
}
