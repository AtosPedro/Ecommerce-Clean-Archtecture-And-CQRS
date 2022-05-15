using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Common.Interfaces;

namespace Ecommerce.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }
        
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }
        
        public void Warn(string message)
        {
            throw new NotImplementedException();
        }
        
        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }
    }
}
