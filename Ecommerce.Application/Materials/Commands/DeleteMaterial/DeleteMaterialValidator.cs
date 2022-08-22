using Ecommerce.Application.Common.DTOs.Materials;
using FluentValidation;

namespace Ecommerce.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialValidator: AbstractValidator<DeleteMaterialDto>
    {
        public DeleteMaterialValidator()
        {
        
        }
    }
}
