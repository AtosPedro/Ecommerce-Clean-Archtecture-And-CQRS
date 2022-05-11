using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
        }
    }
}
