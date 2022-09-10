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
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly AuthenticateUserValidator _validator;

        public AuthenticateUserCommandHandler(
            IUserRepository userRepository, 
            ITokenService tokenService, 
            IMapper mapper)
        {
            _userRepository = userRepository;
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
                var user = (
                    await _userRepository.Search(u => u.UserName == request.User.UserName && u.Password == request.User.Password)
                    ).FirstOrDefault();

                if (user == null)
                    throw new UserNotRegistredException();

                var token = _tokenService.GenerateToken(user);
                var autenticatedUserDto = _mapper.Map<AutenticatedUserDto>(user);
                autenticatedUserDto.Token = token;

                return Response.Ok(autenticatedUserDto, "User authenticated with success");
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = null;

                if (ex is ValidationException)
                {
                    var validationEx = ex as ValidationException;
                    errorResponse = validationEx?.ErrorResponse ?? new ErrorResponse();
                }
                else
                {
                    var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = $"Inner exception: {ex.InnerException}. Message: {ex.Message}" } };
                    errorResponse = new ErrorResponse { Errors = errors };
                }

                return Response.Fail<AutenticatedUserDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
