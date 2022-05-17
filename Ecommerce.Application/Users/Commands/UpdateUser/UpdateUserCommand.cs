using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequestWrapper<ReadUserDto>
    {
        public UpdateUserDto User { get; set; }
    }
    public class UpdateUserCommandHandler : IHandlerWrapper<UpdateUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<ReadUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            var updatedUser = await _userRepository.Update(user);
            var readUser = _mapper.Map<ReadUserDto>(updatedUser);

            if (updatedUser != null)
                return Response.Ok(readUser, "User updated with succes");
            else
                return Response.Fail("User was not updated", readUser);
        }
    }
}
