using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashids _hashId;
        public UserService(IUserRepository userRepository, IHashids hashId)
        {
            _userRepository = userRepository;
            _hashId = hashId;
        }

        public async Task<User> GetById(string hashId)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _userRepository.GetById(id[0]);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _userRepository.GetAll();
            foreach (var user in users)
            {
                user.Guid = _hashId.Encode(user.Id);
            }

            return users;
        }
    }
}
