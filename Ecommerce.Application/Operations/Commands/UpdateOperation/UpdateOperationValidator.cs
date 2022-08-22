using Ecommerce.Application.Common.DTOs.Operations;
using FluentValidation;

namespace Ecommerce.Application.Operations.Commands.UpdateOperation
{
    public class UpdateOperationValidator : AbstractValidator<UpdateOperationDto>
    {
        public UpdateOperationValidator()
        {

        }
    }
}
