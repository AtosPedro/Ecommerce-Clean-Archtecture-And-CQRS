using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Common.Constants;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ecommerce.Application.Common.Behaviours
{
    public class LoggingBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly ILogger<TIn> _loggerConsole;
        private readonly ILogService _logService;

        public LoggingBehavior(ILogger<TIn> logger, ILogService logService)
        {
            _loggerConsole = logger;
            _logService = logService;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            Guid requestId = Guid.NewGuid();
            string? requestName = request.GetType().Name;
            string requestNameWithGuid = $"{requestName} [{requestId}]";

            _loggerConsole.LogInformation($"[START] {requestNameWithGuid}");
            var log = new Log { Id = requestId,  Message = $"[START] {requestNameWithGuid}" };

            await _logService.Info(log);
            TOut response;
            var stopwatch = Stopwatch.StartNew();

            try
            {
                response = await next();
            }
            finally
            {
                stopwatch.Stop();

                log = new Log
                {
                    Id = requestId,
                    Message = $"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms"
                };
                
                _loggerConsole.LogInformation(
                    $"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");

                await _logService.Info(log);

            }

            return response;
        }
    }
}
