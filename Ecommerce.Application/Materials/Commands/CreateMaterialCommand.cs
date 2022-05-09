using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Commands
{
    public class CreateMaterialCommand : BaseRequest, IRequestWrapper<Material> { }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, Material>
    {
        private readonly IMaterialRepository _materialRepository;
        public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public Task<Response<Material>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
