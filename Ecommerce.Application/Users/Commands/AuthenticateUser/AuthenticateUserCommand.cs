using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Users.Commands.AuthenticateUser
{
    public record AuthenticateUserCommand : BaseRequest, IRequestWrapper<AutenticatedUserDto>
    {
        public AutenticatedUserDto User { get; set; }
    }

    public class AuthenticateUserCommandHandler : IHandlerWrapper<AuthenticateUserCommand, AutenticatedUserDto>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly AuthenticateUserValidator _validator;

        public AuthenticateUserCommandHandler(
            IUserService userRepository, 
            ITokenService tokenService, 
            IMapper mapper)
        {
            _userService = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _validator = new AuthenticateUserValidator();
        }

        public async Task<Response<AutenticatedUserDto>> Handle(
            AuthenticateUserCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.GetUserByUserAndPassword(request.User.UserName, request.User.Password, cancellationToken);
                var token = _tokenService.GenerateToken(user);
                var autenticatedUserDto = _mapper.Map<AutenticatedUserDto>(user);
                autenticatedUserDto.Token = token;

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
