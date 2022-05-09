using Ecommerce.Application.Materials.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Common.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllMaterialQuery));
        }
    }
}
