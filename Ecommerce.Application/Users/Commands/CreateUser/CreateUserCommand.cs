﻿using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequestWrapper<ReadUserDto>{
        public CreateUserDto User { get; set; }
    }
    public class CreateUserCommandHandler : IHandlerWrapper<CreateUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(
            IMapper mapper, 
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ReadUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.User.Password != request.User.ConfirmPassword)
                    throw new PasswordConfirmationException();

                var user = _mapper.Map<User>(request.User);
                var createdUser = await _userRepository.Add(user);

                if (createdUser == null)
                    Response.Fail<ReadUserDto>($"Fail to create a user. User was not created", null);

                var readUserDto = _mapper.Map<ReadUserDto>(createdUser);
                await _unitOfWork.Commit();
                return Response.Ok(readUserDto, "User created with success");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };
                
                await _unitOfWork.RollBack();
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
