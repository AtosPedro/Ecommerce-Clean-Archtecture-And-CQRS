using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Users.Queries
{
    public record GetAllUsersQuery : IRequestWrapper<IEnumerable<ReadUserDto>>{}

    public class GetAllUsersQueryHandler : IHandlerWrapper<GetAllUsersQuery, IEnumerable<ReadUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IMapper mapper, IUserService userRepository)
        {
            _mapper = mapper;
            _userService = userRepository;
        }

        public async Task<Response<IEnumerable<ReadUserDto>>> Handle(
            GetAllUsersQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userService.GetAll(cancellationToken);
                var readUsers = _mapper.Map<IEnumerable<ReadUserDto>>(users);
                return Response.Ok(readUsers, "Get all users");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadUserDto>>(ex.Message, ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
