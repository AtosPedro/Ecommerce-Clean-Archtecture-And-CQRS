using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand : IRequestWrapper<ReadUserDto>
    {
        public string Guid { get; set; }
    }
    public class DeleteUserCommandHandler : IHandlerWrapper<DeleteUserCommand, ReadUserDto>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response<ReadUserDto>> Handle(
            DeleteUserCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var readUser = await _userService.Delete(request.Guid, cancellationToken);
                return Response.Ok(readUser, "User updated with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
