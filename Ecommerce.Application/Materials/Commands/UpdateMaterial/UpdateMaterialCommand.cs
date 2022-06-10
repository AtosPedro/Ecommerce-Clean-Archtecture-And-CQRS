using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Materials.Commands
{
    public record UpdateMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public UpdateMaterialDto Material { get; set; }
    }

    public class UpdateMaterialCommandHandler : IHandlerWrapper<UpdateMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public UpdateMaterialCommandHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<Response<ReadMaterialDto>> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = _mapper.Map<Material>(request.Material);
            var updatedMaterial = await _materialRepository.Update(material);
            var readMaterial = _mapper.Map<ReadMaterialDto>(updatedMaterial);

            if (updatedMaterial != null)
                return Response.Ok(readMaterial, "Material updated with succes");
            else
                return Response.Fail<ReadMaterialDto>("Material was not updated", new ErrorResponse());
        }
    }
}
