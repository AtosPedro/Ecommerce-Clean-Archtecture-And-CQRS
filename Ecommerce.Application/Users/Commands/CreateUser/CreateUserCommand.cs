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
        private readonly IUserService _userService;
        private readonly CreateUserValidator _validator;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
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

                var readUserDto = await _userService.Create(request.User, cancellationToken);

                return Response.Ok(readUserDto, "User created with success");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
