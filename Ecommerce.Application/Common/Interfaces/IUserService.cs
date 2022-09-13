using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUserAndPassword(string username, string password);
        Task<User> GetById(string hashId);
        Task<IEnumerable<User>> GetAll();
    }
}
