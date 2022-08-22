using Ecommerce.Application.Common.DTOs.Materials;
using FluentValidation;

namespace Ecommerce.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialValidator : AbstractValidator<UpdateMaterialDto>
    {
        public UpdateMaterialValidator()
        {

        }
    }
}
