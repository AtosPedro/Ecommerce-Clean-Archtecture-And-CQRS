using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
