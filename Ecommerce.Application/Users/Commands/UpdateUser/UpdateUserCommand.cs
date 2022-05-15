using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;

namespace Ecommerce.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequestWrapper<ReadUserDto>{}
    public class UpdateUserCommandHandler : IHandlerWrapper<UpdateUserCommand, ReadUserDto>
    {
        public Task<Response<ReadUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
