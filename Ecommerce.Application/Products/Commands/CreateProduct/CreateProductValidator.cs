using Ecommerce.Application.Common.DTOs.Products;
using FluentValidation;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateProductValidator: AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {

        }
    }
}
