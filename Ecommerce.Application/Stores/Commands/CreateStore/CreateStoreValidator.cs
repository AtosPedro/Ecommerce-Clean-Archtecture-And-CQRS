using Ecommerce.Application.Common.DTOs.Stores;
using FluentValidation;

namespace Ecommerce.Application.Stores.Commands.CreateStore
{
    public class CreateStoreValidator : AbstractValidator<CreateStoreDto>
    {
        public CreateStoreValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("The store must have a name")
                .MaximumLength(80)
                    .WithMessage("Name length must be less than 80")
                .MinimumLength(5)
                    .WithMessage("Name length must be more than 5");
        }
    }
}
