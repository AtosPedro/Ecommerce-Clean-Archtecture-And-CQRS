using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;
using HashidsNet;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;

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

        public async Task<User> GetById(string hashId, CancellationToken cancellationToken)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _userRepository.GetById(id[0], cancellationToken);

            if (user != null)
                user.Guid = hashId;

            return user;
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll(cancellationToken);
            foreach (var user in users)
            {
                user.Guid = _hashId.Encode(user.Id);
            }

            return users;
        }

        public async Task<User> GetUserByUserAndPassword(
            string username, 
            string password, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.Search(u => u.UserName == username && u.Password == password, cancellationToken);
            if (user == null)
                throw new UserNotRegistredException();

            return user?.FirstOrDefault();
        }

        public async Task<User> Update(User user)
        {
            await _userRepository.Update(user);
            return user;
        }
    }
}
