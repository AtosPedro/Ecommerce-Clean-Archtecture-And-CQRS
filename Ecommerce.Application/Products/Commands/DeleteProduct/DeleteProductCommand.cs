using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Products.Commands
{
    public record DeleteProductCommand : BaseRequest, IRequestWrapper<ReadProductDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteMaterialCommandHandler : IHandlerWrapper<DeleteProductCommand, ReadProductDto>
    {
        private readonly IProductService _productService;

        public DeleteMaterialCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Response<ReadProductDto>> Handle(
            DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var readProduct = await _productService.Delete(request.Guid, cancellationToken);
                return Response.Ok(readProduct, "Product deleted with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadProductDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }

        }
    }
}
