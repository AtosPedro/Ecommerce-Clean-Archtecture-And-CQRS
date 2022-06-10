using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Security;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecommerce.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<IApplicationDbContext, MySqlApplicationDbContext>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IOperationalUnitRepository, OperationalUnitRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<ILogRepository, LogFireBaseRepository>();
            services.AddScoped<ILogService, LogService>();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
