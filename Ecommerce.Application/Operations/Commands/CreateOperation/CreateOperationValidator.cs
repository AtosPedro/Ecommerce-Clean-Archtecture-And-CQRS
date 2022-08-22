﻿using Ecommerce.Application.Common.DTOs.Operations;
using FluentValidation;

namespace Ecommerce.Application.Operations.Commands.CreateOperation
{
    public class CreateOperationValidator : AbstractValidator<CreateOperationDto>
    {
        public CreateOperationValidator()
        {
            RuleFor(ope => ope.StoreId)
                .NotEmpty()
                    .WithMessage("The operation must have a store") ;

            RuleFor(ope => ope.OperationalUnitId)
                .NotEmpty()
                    .WithMessage("The operation must have a unit");
            
            RuleFor(ope => ope.MaterialId)
                .NotEmpty()
                    .WithMessage("The operation must have a product");

            RuleFor(ope => ope.Price)
                .NotEmpty()
                    .WithMessage("The operation must have a price")
                .GreaterThan(0)
                    .WithMessage("The operation must have a price greater than 0");

            RuleFor(ope => ope.Date)
                .NotEmpty()
                    .WithMessage("The operation must have a date");
        }
    }
}
