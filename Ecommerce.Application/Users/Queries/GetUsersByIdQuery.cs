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
                var readUser = await _userService.GetById(request.Guid,cancellationToken);
                return Response.Ok(readUser, "Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadUserDto>($"Fail to get the user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
