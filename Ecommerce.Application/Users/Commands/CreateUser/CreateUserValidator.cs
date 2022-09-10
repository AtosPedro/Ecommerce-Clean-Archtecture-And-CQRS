using Ecommerce.Application.Common.DTOs.Users;
using FluentValidation;

namespace Ecommerce.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(usr => usr.ConfirmPassword)
                .Equal(usr => usr.Password)
                    .WithMessage("The password and the confirmation doesn't match")
                .NotEmpty()
                    .WithMessage("The confirmation must have a value");

        }
    }
}
