using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Materials;

namespace Ecommerce.Application.Materials.Commands
{
    public record CreateMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public CreateMaterialDto Material { get; set; }
    }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public CreateMaterialCommandHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReadMaterialDto>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = _mapper.Map<Material>(request.Material);
            var createdMaterial = await _materialRepository.Add(material);
            var readMaterial = _mapper.Map<ReadMaterialDto>(createdMaterial);

            if (createdMaterial != null)
                return Response.Ok(readMaterial, "Material created with succes");
            else
                return Response.Fail("Material was not created", readMaterial);
        }
    }

}
