using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ecommerce.Application.Common.Behaviours
{
    public class LoggingBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly ILogger<TIn> _logger;

        public LoggingBehavior(ILogger<TIn> logger)
        {
            _logger = logger;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            string? requestName = request.GetType().Name;
            string? requestGuid = Guid.NewGuid().ToString();
            string requestNameWithGuid = $"{requestName} [{requestGuid}]";
            _logger.LogInformation($"[START] {requestNameWithGuid}");
            TOut response;
            var stopwatch = Stopwatch.StartNew();

            try
            {
                response = await next();
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation(
                    $"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
            }

            return response;
        }
    }
}
