using Ecommerce.Application.Common.Behaviours;
using Ecommerce.Application.Common.Interfaces;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application.Common.Extensions
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
