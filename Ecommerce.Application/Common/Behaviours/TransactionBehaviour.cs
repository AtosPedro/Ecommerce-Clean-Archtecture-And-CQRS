using MediatR;

namespace Ecommerce.Application.Common.Behaviours
{
    public class TransactionBehaviour<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            throw new NotImplementedException();
        }
    }
}
