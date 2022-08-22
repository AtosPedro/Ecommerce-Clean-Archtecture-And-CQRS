using Ecommerce.Application.Common.DTOs.Materials;
using FluentValidation;

namespace Ecommerce.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialValidator: AbstractValidator<CreateMaterialDto>
    {
        public CreateMaterialValidator()
        {

        }
    }
}
