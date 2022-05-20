using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public CurrentUser GetCurrent()
        {
            return new CurrentUser(_accessor);
        }
    }
}
