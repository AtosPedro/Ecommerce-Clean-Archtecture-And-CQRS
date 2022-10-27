using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Sync
{
    public class Application
    {
        private readonly ISyncService _syncService;

        public Application(ISyncService syncService)
        {
            _syncService = syncService;
        }

        public void Run()
        {

        }
    }
}
