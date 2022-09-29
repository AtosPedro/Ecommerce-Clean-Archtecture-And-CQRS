using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequestWrapper<ReadUserDto>
    {
        public UpdateUserDto User { get; set; }
    }
    public class UpdateUserCommandHandler : IHandlerWrapper<UpdateUserCommand, ReadUserDto>
    {
        private readonly IUserService _userService;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
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

                var readUser = await _userService.Update(request.User, cancellationToken);
                return Response.Ok(readUser, "User updated with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>($"Fail to update the user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
