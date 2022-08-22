using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;
using System.Diagnostics;

namespace Ecommerce.Application.Common.Behaviours
{
    public class LoggingBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly ILogService _logService;

        public LoggingBehavior(ILogService logService)
        {
            _logService = logService;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var stopwatch = Stopwatch.StartNew();
            Guid requestId = Guid.NewGuid();
            TOut response = default(TOut);
            var log = new Log { Id = requestId, RequestId = requestId, ResponseId = null,  Message = $"[START] {request.GetType().Name}" };
            await _logService.Info(log);

            try
            {
                response = await next();
            }
            catch (Exception ex)
            {
                var guid = Guid.NewGuid();
                log = new Log
                {
                    Id = guid,
                    RequestId = requestId,
                    Message = $"[ERROR] {request.GetType().Name}; Error='{ex.Message}'",
                    Data = response
                };

                await _logService.Error(log);
            }
            finally
            {
                stopwatch.Stop();
                var guid = Guid.NewGuid();
                log = new Log
                {
                    Id = guid,
                    RequestId = requestId,
                    ResponseId = guid,
                    Message = $"[END] {request.GetType().Name}; Execution time={stopwatch.ElapsedMilliseconds}ms",
                    Data = response
                };

                await _logService.Info(log);
            }

            return response;
        }
    }
}
