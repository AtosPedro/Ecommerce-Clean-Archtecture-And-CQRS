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
        private readonly IUnitOfWork _unitOfWork;

        public CreateMaterialCommandHandler(
            IMaterialRepository materialRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Response<ReadMaterialDto>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var material = _mapper.Map<Material>(request.Material);
                var createdMaterial = await _materialRepository.Add(material);
                var readMaterial = _mapper.Map<ReadMaterialDto>(createdMaterial);

                if (createdMaterial == null)
                    return Response.Fail<ReadMaterialDto>("Material was not created", null);

                await _unitOfWork.Commit();
                return Response.Ok(readMaterial, "Material created with succes");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<ReadMaterialDto>("", errorResponse);
            }
        }
    }

}
