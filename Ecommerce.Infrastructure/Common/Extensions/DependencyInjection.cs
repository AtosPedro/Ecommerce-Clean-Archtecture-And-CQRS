﻿using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Security;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Infrastructure.Services;
using HashidsNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

namespace Ecommerce.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IIdentityService, IdentityService>();
            services.AddSingleton<IHashids>(_ => new Hashids(Settings.Secret,11));
            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect("redis-server:6379"));
            services.AddSingleton<ICacheService, RedisCacheService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISyncService, SyncService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicationWriteDbContext, MySqlApplicationWriteDbContext>();
            services.AddScoped<IApplicationReadDbContext, MySqlApplicationReadDbContext>();
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
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOperationalUnitService, OperationalUnitService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISupplierService, SupplierService>();

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

        public static void MigrateDatabase(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var syncService = services.GetRequiredService<ISyncService>();
                if( syncService.SyncMasterAndSlaveDb())
                {
                    var context = services.GetRequiredService<IApplicationWriteDbContext>();
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
