using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetMaterialByIdQuery : BaseRequest, IRequest<Material>
    {
        public int Id { get; set; }
    }

    public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQuery, Material>
    {
        public Task<Material> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
