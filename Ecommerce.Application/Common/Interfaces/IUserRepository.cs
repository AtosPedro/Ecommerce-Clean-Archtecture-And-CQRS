using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
        public Task<User> GetById(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);
        public Task<User> Add(User user, CancellationToken cancellationToken);
        public Task<User> Update(User user);
        public Task<User> Remove(User user);
    }
}