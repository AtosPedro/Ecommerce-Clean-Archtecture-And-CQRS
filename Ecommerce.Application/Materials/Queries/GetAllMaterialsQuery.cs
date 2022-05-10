using MediatR;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetAllMaterialQuery : BaseRequest, IRequest<IEnumerable<Material>> { }
    public class GetAllMaterialQueryHandler : IRequestHandler<GetAllMaterialQuery, IEnumerable<Material>>
    {
        private readonly IMaterialRepository _materialRepository;
        public GetAllMaterialQueryHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public async Task<IEnumerable<Material>> Handle(GetAllMaterialQuery request, CancellationToken cancellationToken)
        {
            return await _materialRepository.GetAll();
        }
    }
}
