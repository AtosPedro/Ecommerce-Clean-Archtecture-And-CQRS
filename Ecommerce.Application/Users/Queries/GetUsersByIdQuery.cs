using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Users.Queries
{
    public record GetUsersByIdQuery : IRequestWrapper<ReadUserDto>
    {
        public int Id { get; set; }
    }
    public class GetUsersByIdQueryHandler : IHandlerWrapper<GetUsersByIdQuery, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUsersByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<ReadUserDto>> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetById(request.Id);
                var readUsers = _mapper.Map<ReadUserDto>(users);
                return Response.Ok(readUsers, "Get all users");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>(ex.Message);
            }
        }
    }
}
