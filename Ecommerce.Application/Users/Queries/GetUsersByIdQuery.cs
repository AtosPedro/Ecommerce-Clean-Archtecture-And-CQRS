using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Users.Queries
{
    public record GetUsersByIdQuery : IRequestWrapper<ReadUserDto>
    {
        public string Guid { get; set; }
    }
    public class GetUsersByIdQueryHandler : IHandlerWrapper<GetUsersByIdQuery, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetUsersByIdQueryHandler(IMapper mapper, IUserService userRepository)
        {
            _mapper = mapper;
            _userService = userRepository;
        }

        public async Task<Response<ReadUserDto>> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.GetById(request.Guid,cancellationToken);
                if (user == null)
                    throw new NotFoundException("User not found!");

                var readUsers = _mapper.Map<ReadUserDto>(user);
                readUsers.Guid = request.Guid;

                return Response.Ok(readUsers, "Get all users");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
