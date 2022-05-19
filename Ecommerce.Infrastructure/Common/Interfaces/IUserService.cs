using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Infrastructure.Common.Interfaces
{
    public interface IUserService
    {
        CurrentUser GetCurrent();
    }
}
