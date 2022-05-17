using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand : IRequestWrapper<ReadUserDto>
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandler : IHandlerWrapper<DeleteUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<ReadUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            var sucess = await _userRepository.Remove(user);
            var readUser = _mapper.Map<ReadUserDto>(sucess);

            if (user != null)
                return Response.Ok(readUser, "User updated with succes");
            else
                return Response.Fail("User was not updated", readUser);
        }
    }
}
