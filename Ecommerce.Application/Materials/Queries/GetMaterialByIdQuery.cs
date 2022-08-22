using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetMaterialByIdQuery : BaseRequest, IRequestWrapper<Material>
    {
        public int MaterialId { get; set; }
    }

    public class GetMaterialByIdQueryHandler : IHandlerWrapper<GetMaterialByIdQuery, Material>
    {
        private readonly IMaterialRepository _materialRepository;
        public GetMaterialByIdQueryHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Response<Material>> Handle(
            GetMaterialByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetById(request.MaterialId);
            return Response.Ok(material, "");
        }
    }
}
