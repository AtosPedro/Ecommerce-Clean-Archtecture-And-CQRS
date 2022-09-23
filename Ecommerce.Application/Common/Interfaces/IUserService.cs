using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByUserAndPassword(string username, string password, CancellationToken cancellationToken);
        public Task<User> GetById(string hashId, CancellationToken cancellationToken);
        public Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
        public Task<User> Update(User user);
    }
}
