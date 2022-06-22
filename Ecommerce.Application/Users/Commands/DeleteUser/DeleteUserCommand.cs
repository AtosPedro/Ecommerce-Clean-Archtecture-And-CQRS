using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand : IRequestWrapper<ReadUserDto>
    {
        public int UserId { get; set; }
    }
    public class DeleteUserCommandHandler : IHandlerWrapper<DeleteUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ReadUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.UserId == 0)
                    throw new InvalidIdException("Invalid Id");

                var user = await _userRepository.GetById(request.UserId);

                if (user == null)
                    throw new EntityNotFoundException();

                var sucess = await _userRepository.Remove(user);
                var readUser = _mapper.Map<ReadUserDto>(sucess);
                
                await _unitOfWork.Commit();
                return Response.Ok(readUser, "User updated with succes");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<ReadUserDto>("User was not updated", errorResponse);
            }
        }
    }
}
