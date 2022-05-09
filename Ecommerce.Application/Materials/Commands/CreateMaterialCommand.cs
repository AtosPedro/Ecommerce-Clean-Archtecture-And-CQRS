using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Commands
{
    public class CreateMaterialCommand : IRequestWrapper<Material> { }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, Material>
    {
        public Task<Response<Material>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
