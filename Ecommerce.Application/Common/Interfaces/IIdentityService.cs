using Ecommerce.Application.Common.Communication;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        CurrentUser GetCurrent();
    }
}
