using MediatR;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetAllMaterialsQuery : BaseRequest, IRequestWrapper<IEnumerable<Material>> { }
    public class GetAllMaterialQueryHandler : IHandlerWrapper<GetAllMaterialsQuery, IEnumerable<Material>>
    {
        private readonly IMaterialRepository _materialRepository;
        public GetAllMaterialQueryHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public async Task<Response<IEnumerable<Material>>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetAll();
            return Response.Ok(materials, "");
        }
    }
}
