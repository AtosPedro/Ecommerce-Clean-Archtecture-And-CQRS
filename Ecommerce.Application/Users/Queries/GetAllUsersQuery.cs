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
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<IEnumerable<ReadUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAll();
                var readUsers = _mapper.Map<IEnumerable<ReadUserDto>>(users);
                return Response.Ok(readUsers, "Get all users");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                return Response.Fail<IEnumerable<ReadUserDto>>(ex.Message, errorResponse);
            }
        }
    }
}
