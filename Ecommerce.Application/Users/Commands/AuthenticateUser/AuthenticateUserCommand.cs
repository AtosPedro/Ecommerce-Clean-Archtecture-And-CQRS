using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Users.Commands.AuthenticateUser
{
    public record AuthenticateUserCommand : BaseRequest, IRequestWrapper<AutenticatedUserDto>
    {
        public AutenticatedUserDto User { get; set; }
    }

    public class AuthenticateUserCommandHandler : IHandlerWrapper<AuthenticateUserCommand, AutenticatedUserDto>
    {
        private readonly IUserService _userService;
        private readonly AuthenticateUserValidator _validator;

        public AuthenticateUserCommandHandler(IUserService userRepository)
        {
            _userService = userRepository;
            _validator = new AuthenticateUserValidator();
        }

        public async Task<Response<AutenticatedUserDto>> Handle(
            AuthenticateUserCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.User);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var autenticatedUserDto = await _userService.AutenticateUser(
                    request.User.UserName, 
                    request.User.Password, 
                    cancellationToken);

                return Response.Ok(autenticatedUserDto, "User authenticated with success");
            }
            catch (Exception ex)
            {
                var errorResponse = ErrorHandler.HandleApplicationError(ex);
                return Response.Fail<AutenticatedUserDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
