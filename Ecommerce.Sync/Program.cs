using Ecommerce.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Sync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startup.InjectServices();
            var application = new Application(Startup.ServiceProvider.GetRequiredService<ISyncService>());
            application.Run();
        }
    }
}