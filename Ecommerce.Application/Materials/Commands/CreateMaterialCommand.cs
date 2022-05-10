using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Materials.DTOs;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Commands
{
    public class CreateMaterialCommand : BaseRequest, IRequestWrapper<Material>
    {
        public Material Material { get; set; }
        private ReadMaterialDto ReadMaterialDto { get; set; }
    }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, Material>
    {
        private readonly IMaterialRepository _materialRepository;
        public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Response<Material>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var data = await _materialRepository.Add(request.Material);
            return Response.Ok(data, "Material Created");
        }
    }

}
