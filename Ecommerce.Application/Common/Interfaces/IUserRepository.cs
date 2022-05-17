using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Remove(User user);
    }
}