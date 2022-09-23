using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequestWrapper<ReadUserDto>{
        public CreateUserDto User { get; set; }
    }
    public class CreateUserCommandHandler : IHandlerWrapper<CreateUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateUserValidator _validator;

        public CreateUserCommandHandler(
            IMapper mapper, 
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _validator = new CreateUserValidator();
        }

        public async Task<Response<ReadUserDto>> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.User);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var user = _mapper.Map<User>(request.User);
                await _userRepository.Add(user, cancellationToken);

                var readUserDto = _mapper.Map<ReadUserDto>(user);
                await _unitOfWork.Commit();
                return Response.Ok(readUserDto, "User created with success");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
