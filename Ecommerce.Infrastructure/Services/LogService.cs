using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Common.Constants;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task Info(Log log)
        {
            log.Type = LogTypes.Info;
            log.CreatedAt = DateTime.Now;
            await _logRepository.Add(log, log.Id);
        }

        public async Task<IEnumerable<Log>> GetAll()
        {
            return await _logRepository.GetAsync();
        }
    }
}
