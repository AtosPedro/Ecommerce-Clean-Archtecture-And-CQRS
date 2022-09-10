﻿using AutoMapper;
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
        public DeleteUserDto DeleteUserDto { get; set; }
    }
    public class DeleteUserCommandHandler : IHandlerWrapper<DeleteUserCommand, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeleteUserValidator _validator;

        public DeleteUserCommandHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _validator = new DeleteUserValidator();
        }

        public async Task<Response<ReadUserDto>> Handle(
            DeleteUserCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.DeleteUserDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var user = await _userRepository.GetById(request.DeleteUserDto.Id);
                await _userRepository.Remove(user);

                var readUser = _mapper.Map<ReadUserDto>(user);
                await _unitOfWork.Commit();
                return Response.Ok(readUser, "User updated with succes");
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

                await _unitOfWork.RollBack();
                return Response.Fail<ReadUserDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
