using Ecommerce.Application.Common.DTOs.Products;
using FluentValidation;

namespace Ecommerce.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {

        }
    }
}
