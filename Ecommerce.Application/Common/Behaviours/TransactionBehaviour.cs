using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using MediatR;

namespace Ecommerce.Application.Common.Behaviours
{
    public class TransactionBehaviour<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly IRequestHandler<TIn, TOut> _handler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehaviour(
            IRequestHandler<TIn, TOut> handler,
            IUnitOfWork unitOfWork)
        {
            _handler = handler;
            _unitOfWork = unitOfWork;
        }
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            TOut response = default(TOut);
            try
            {
                response = await next();
                if (_handler is BaseCommand)
                {
                    await _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollBack();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
            return response;
        }
    }
}
