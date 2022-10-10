using Ecommerce.Application.Common.DTOs.Products;
using FluentValidation;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateMaterialValidator: AbstractValidator<CreateProductDto>
    {
        public CreateMaterialValidator()
        {

        }
    }
}
