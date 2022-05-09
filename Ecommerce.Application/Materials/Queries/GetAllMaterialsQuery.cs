using MediatR;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Materials.Queries
{
    public class GetAllMaterialQuery : IRequest<IEnumerable<Material>> { }
    public class GetAllMaterialQueryHandler : IRequestHandler<GetAllMaterialQuery, IEnumerable<Material>>
    {
        public async Task<IEnumerable<Material>> Handle(GetAllMaterialQuery request, CancellationToken cancellationToken)
        {
            return new[]
            {
                new Material{ Name = "Arroz", Code ="a12", Price = 27.3m},
                new Material{ Name = "Arroz2", Code ="a123", Price = 22.3m},
                new Material{ Name = "Arroz4", Code ="a125", Price = 26.3m},
            };
        }
    }
}
