using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Extensions;
using Ecommerce.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Services
{
    public class SyncDB
    {
        public string File { get; set; }
        public Int64 Position { get; set; }
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

        public bool SyncWriteAndReadDBs()
        {
            var masterStatus = WriteContext.Database.FromSqlQuery("SHOW MASTER STATUS;", x => new SyncDB
            {
                File = (string)x[0],
                Position = Convert.ToInt64(x[1]),
            }).FirstOrDefault();

            if (masterStatus == null)
                throw new Exception("Erro ao sincronizar os bancos de dados. Não foi encontrado o status do banco master");

            ReadContext.Database.ExecuteSqlRaw("STOP SLAVE;");
            ReadContext.Database.ExecuteSqlRaw("RESET SLAVE;");
            ReadContext.Database.ExecuteSqlRaw("SET GLOBAL server_id={0};",2);
            ReadContext.Database.ExecuteSqlRaw(
                "CHANGE MASTER TO " +
                "MASTER_HOST='mysql-master'," +
                "MASTER_USER='replication'," +
                "MASTER_PASSWORD='Slaverepl123', " +
                "MASTER_LOG_FILE={0}," +
                "MASTER_LOG_POS={1};",
                masterStatus?.File, 
                masterStatus?.Position);
            ReadContext.Database.ExecuteSqlRaw("START SLAVE;");

            return masterStatus != null;
        }
    }
}
