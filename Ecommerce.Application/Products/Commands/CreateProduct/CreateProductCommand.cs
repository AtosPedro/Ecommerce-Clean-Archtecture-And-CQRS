using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Exceptions;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Products.Commands
{
    public record CreateProductCommand : BaseRequest, IRequestWrapper<ReadProductDto>
    {
        public CreateProductDto Product { get; set; }
    }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateProductCommand, ReadProductDto>
    {
        private readonly IProductService _productService;
        private readonly CreateProductValidator _validator;

        public CreateMaterialCommandHandler(IProductService materialService)
        {
            _productService = materialService;
            _validator = new CreateProductValidator();
        }

        public async Task<Response<ReadProductDto>> Handle(
            CreateProductCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Product);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readMaterial = await _productService.Create(request.Product, cancellationToken);

                return Response.Ok(readMaterial, "Material created with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadProductDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}