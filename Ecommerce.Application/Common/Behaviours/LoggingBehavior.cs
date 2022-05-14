using MediatR;
namespace Ecommerce.Application.Common.Behaviours
{
    public class LoggingBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        public LoggingBehavior()
        {

        }
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            throw new NotImplementedException();
        }
    }
}
