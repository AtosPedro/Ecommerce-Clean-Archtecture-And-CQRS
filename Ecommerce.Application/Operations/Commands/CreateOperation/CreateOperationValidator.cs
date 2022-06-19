using Ecommerce.Application.Common.DTOs.Operations;
using FluentValidation;

namespace Ecommerce.Application.Operations.Commands.CreateOperation
{
    public class CreateOperationValidator : AbstractValidator<CreateOperationDto>
    {
        public CreateOperationValidator()
        {
            RuleFor(ope => ope.StoreId)
                .LessThanOrEqualTo(0)
                    .WithMessage("The operation must have a store") ;

            RuleFor(ope => ope.OperationalUnitId)
                .LessThanOrEqualTo(0)
                    .WithMessage("The operation must have a unit");
            
            RuleFor(ope => ope.MaterialId)
                .LessThanOrEqualTo(0)
                    .WithMessage("The operation must have a product");

            RuleFor(ope => ope.Price)
                .LessThanOrEqualTo(0)
                    .WithMessage("The operation must have a product");

            RuleFor(ope => ope.Date)
                .NotEmpty()
                    .WithMessage("The operation must have a date");
        }
    }
}
