using Ecommerce.Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Infrastructure.Services
{
    public class CurrentUser
    {
        public bool IsAuthenticated{get { return _accessor.HttpContext.User.Identity.IsAuthenticated; }}
        public string Name {get { return _accessor.HttpContext.User.Identity.Name; }}
        public string Email { get { return _accessor.HttpContext.User.GetEmail(); } }

        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
