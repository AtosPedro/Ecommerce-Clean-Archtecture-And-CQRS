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
                    .WithMessage("The store must have a Name")
                .MaximumLength(50)
                    .WithMessage("Name length must be less than 50")
                .MinimumLength(5)
                    .WithMessage("Name length must be more than 5");

            RuleFor(m => m.FullName)
                .NotEmpty()
                    .WithMessage("The store must have a Full Name")
                .MaximumLength(80)
                    .WithMessage("FullName length must be less than 80")
                .MinimumLength(5)
                    .WithMessage("FullName length must be more than 5");

            RuleFor(m => m.FullName)
                .NotEmpty()
                    .WithMessage("The store must have a CNPJ")
                .MaximumLength(18)
                    .WithMessage("CNPJ length must be 18")
                .MinimumLength(18)
                    .WithMessage("CNPJ length must be 18");
        }
    }
}
