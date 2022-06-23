using Ecommerce.Application.Common.DTOs.Users;
using FluentValidation;

namespace Ecommerce.Application.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {

        }
    }
}
