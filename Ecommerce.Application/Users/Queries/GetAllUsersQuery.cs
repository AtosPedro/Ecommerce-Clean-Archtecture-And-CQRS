using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;

namespace Ecommerce.Application.Users.Queries
{
    public record GetAllUsersQuery : IRequestWrapper<IEnumerable<ReadUserDto>>{}

    public class GetAllUsersQueryHandler : IHandlerWrapper<GetAllUsersQuery, IEnumerable<ReadUserDto>>
    {
        public Task<Response<IEnumerable<ReadUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
