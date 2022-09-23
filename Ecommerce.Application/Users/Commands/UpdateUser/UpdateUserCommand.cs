using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
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
        private readonly IUserService _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommandHandler(
            IMapper mapper, 
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userService;
            _unitOfWork = unitOfWork;
            _validator = new UpdateUserValidator();
        }

        public async Task<Response<ReadUserDto>> Handle(
            UpdateUserCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.User);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var user = await _userRepository.GetById(request.User.Guid, cancellationToken);
                if (user == null)
                    throw new NotFoundException();

                _mapper.Map(request.User, user);
                await _userRepository.Update(user);

                var readUser = _mapper.Map<ReadUserDto>(user);
                await _unitOfWork.Commit();
                return Response.Ok(readUser, "User updated with succes");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
