using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public User User { get; }
    }
}
