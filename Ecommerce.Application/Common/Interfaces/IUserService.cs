using Ecommerce.Application.Common.DTOs.Users;

namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<AutenticatedUserDto> AutenticateUser(
                    AutenticatedUserDto authUser,
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
