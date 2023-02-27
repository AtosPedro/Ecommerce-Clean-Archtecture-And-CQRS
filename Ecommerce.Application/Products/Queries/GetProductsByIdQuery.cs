using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Products.Queries
{
    public record GetProductsByIdQuery : BaseRequest, IRequestWrapper<Product>
    {
        public int Guid { get; set; }
    }

    public class GetProductByIdQueryHandler : IHandlerWrapper<GetProductsByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<Product>> Handle(
            GetProductsByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Guid, cancellationToken);
            return Response.Ok(product, "");
        }
    }
}
