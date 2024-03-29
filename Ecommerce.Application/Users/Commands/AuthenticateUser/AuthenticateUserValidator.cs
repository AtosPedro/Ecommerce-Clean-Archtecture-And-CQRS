﻿using Ecommerce.Application.Common.DTOs.Users;
using FluentValidation;

namespace Ecommerce.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserValidator : AbstractValidator<AutenticatedUserDto>
    {
        public AuthenticateUserValidator()
        {            
            RuleFor(a => a.UserName)
                .NotEmpty()
                    .WithMessage("The field username is required")
                .MaximumLength(80)
                    .WithMessage("The field username length must be less than 20");

            RuleFor(a => a.Password)
                .NotEmpty()
                    .WithMessage("The field password is required");
        }
    }
}
