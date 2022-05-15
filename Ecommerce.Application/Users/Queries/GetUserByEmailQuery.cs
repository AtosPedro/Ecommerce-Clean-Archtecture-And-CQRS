using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;

namespace Ecommerce.Application.Users.Queries
{
    public record GetUserByEmailQuery : IRequestWrapper<ReadUserDto>{}
    public class GetUserByEmailQueryHandler : IHandlerWrapper<GetUserByEmailQuery, ReadUserDto>
    {
        public Task<Response<ReadUserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
