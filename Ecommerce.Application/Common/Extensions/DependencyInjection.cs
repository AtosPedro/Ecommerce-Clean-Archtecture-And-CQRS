using Ecommerce.Application.Common.Behaviours;
using Ecommerce.Application.Stores.Commands.CreateStore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
