using Ecommerce.Application.Common.Extensions;
using Ecommerce.DesktopUI.Forms;
using Ecommerce.Infrastructure.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.DesktopUI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddApplication()
                .AddInfrastructure();
            
            ServiceProvider = services.BuildServiceProvider();
        }

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);

            ConfigureServices();
            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}