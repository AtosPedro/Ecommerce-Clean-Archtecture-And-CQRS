using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<AutenticatedUserDto> AutenticateUser(
                    string username,
                    string password,
                    CancellationToken cancellationToken);
        public Task<ReadUserDto> GetById(
            string hashId, 
            CancellationToken cancellationToken);
        public Task<IEnumerable<ReadUserDto>> GetAll(CancellationToken cancellationToken);
        Task<ReadUserDto> Update(
            UpdateUserDto userDto, 
            CancellationToken cancellationToken);
        Task<ReadUserDto> Delete(
            string Guid, 
            CancellationToken cancellationToken);
        Task<ReadUserDto> Create(
            CreateUserDto userDto,
            CancellationToken cancellationToken);
    }
}
