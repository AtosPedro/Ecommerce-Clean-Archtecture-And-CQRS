using Microsoft.Extensions.Hosting;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Infrastructure.Common.Extensions;

namespace Ecommerce.Sync
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static void InjectServices()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddApplication();
                    services.AddInfrastructure();
                });
        }
    }
}
