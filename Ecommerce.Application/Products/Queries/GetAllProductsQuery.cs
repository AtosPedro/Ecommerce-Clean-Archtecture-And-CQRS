using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Infrastructure.Services;
using AutoMapper;
using Ecommerce.Application.Common.DTOs.Products;

namespace Ecommerce.Application.Products.Queries
{
    public record GetAllProductsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadProductDto>> { }
    public class GetAllProductQueryHandler : IHandlerWrapper<GetAllProductsQuery, IEnumerable<ReadProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(
            IProductService productRepository, 
            IMapper mapper)
        {
            _productService = productRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ReadProductDto>>> Handle(
            GetAllProductsQuery request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var readProduct = await _productService.GetAll(cancellationToken);
                return Response.Ok(readProduct, "");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadProductDto>>(
                    $"Fail to create a user. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
