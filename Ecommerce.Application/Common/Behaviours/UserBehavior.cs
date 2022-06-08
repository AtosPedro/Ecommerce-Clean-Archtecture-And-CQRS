using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using MediatR;

namespace Ecommerce.Application.Common.Behaviours
{
    public class UserBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly IUserService _userService;
        private readonly CurrentUser _currentUser;

        public UserBehavior(IUserService userService)
        {
            _userService = userService;
            _currentUser = userService.GetCurrent();
        }

        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            if (request is BaseRequest br)
            {
                br.UserEmail = _currentUser.Email;
                br.UserName = _currentUser.Name;
            }

            return next();
        }
    }
}
