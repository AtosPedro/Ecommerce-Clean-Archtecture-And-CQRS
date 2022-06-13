using Ecommerce.Application.Common.DTOs.OperationalUnits;
using FluentValidation;

namespace Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit
{
    public class UpdateOperationalUnitValidator : AbstractValidator<UpdateOperationalUnitDto>
    {
        public UpdateOperationalUnitValidator()
        {
        }
    }
}
