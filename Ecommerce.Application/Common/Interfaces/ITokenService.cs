using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
