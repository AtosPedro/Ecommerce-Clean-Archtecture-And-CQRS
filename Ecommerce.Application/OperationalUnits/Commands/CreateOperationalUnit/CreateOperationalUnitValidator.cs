using Ecommerce.Application.Common.DTOs.OperationalUnits;
using FluentValidation;

namespace Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnit
{
    public class CreateOperationalUnitValidator : AbstractValidator<CreateOperationalUnitDto>
    {
        public CreateOperationalUnitValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("The operational unit must have a name")
                .MaximumLength(20)
                    .WithMessage("Name length must be less than 20")
                .MinimumLength(5)
                    .WithMessage("Name length must be more than 5");

            RuleFor(c => c.Address)
                .NotEmpty()
                    .WithMessage("The operational unit must have a address")
                .MaximumLength(80)
                    .WithMessage("Address length must be less than 80")
                .MinimumLength(5)
                    .WithMessage("Address length must be more than 5");

            RuleFor(c => c.StoreId)
                .NotEmpty()
                    .WithMessage("The operational unit must have a store")
                .NotEqual(0)
                    .WithMessage("The storeId is invalid");
        }
    }
}
