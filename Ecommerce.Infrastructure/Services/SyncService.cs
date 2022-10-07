using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Services
{
    public class SyncDB
    {
        public string File { get; set; }
        public int Position { get; set; }
    }

    public class SyncService : ISyncService
    {
        protected readonly IApplicationWriteDbContext WriteContext;
        protected readonly IApplicationReadDbContext ReadContext;
        public SyncService(
            IApplicationWriteDbContext writeContext, 
            IApplicationReadDbContext readContext)
        {
            WriteContext = writeContext;
            ReadContext = readContext;
        }

        public bool SyncMasterAndSlaveDb()
        {

            var syncDB = WriteContext.Database.ExecuteSqlRaw("SHOW MASTER STATUS;");

            return false;
        }
    }
}
