using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Materials.Commands
{
    public record DeleteMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public int MaterialId { get; set; }
    }

    public class DeleteMaterialCommandHandler : IHandlerWrapper<DeleteMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public DeleteMaterialCommandHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReadMaterialDto>> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetById(request.MaterialId);
            var deletedMaterial = await _materialRepository.Remove(material);
            var readMaterial = _mapper.Map<ReadMaterialDto>(deletedMaterial);

            if (deletedMaterial != null)
                return Response.Ok(readMaterial, "Material deleted with succes");
            else
                return Response.Fail("Material was not deleted",null, readMaterial);
        }
    }
}
