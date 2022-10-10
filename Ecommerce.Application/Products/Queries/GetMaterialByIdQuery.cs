using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Products.Queries
{
    public record GetMaterialByIdQuery : BaseRequest, IRequestWrapper<Product>
    {
        public int Guid { get; set; }
    }

    public class GetMaterialByIdQueryHandler : IHandlerWrapper<GetMaterialByIdQuery, Product>
    {
        private readonly IProductRepository _materialRepository;
        public GetMaterialByIdQueryHandler(IProductRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Response<Product>> Handle(
            GetMaterialByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetById(request.Guid, cancellationToken);
            return Response.Ok(material, "");
        }
    }
}
