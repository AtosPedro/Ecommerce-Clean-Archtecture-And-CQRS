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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(
            IMapper mapper, 
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ReadUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request.User);
                var updatedUser = await _userRepository.Update(user);

                if (updatedUser == null)
                    return Response.Fail<ReadUserDto>("User was not updated", new ErrorResponse());

                var readUser = _mapper.Map<ReadUserDto>(updatedUser);
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
