using Ecommerce.Application.Common.Communication;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserService
    {
        CurrentUser GetCurrent();
    }
}
