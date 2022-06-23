using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Materials.Commands.UpdateMaterial;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateMaterialValidator _validator;

        public UpdateMaterialCommandHandler(
            IMaterialRepository materialRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new UpdateMaterialValidator();
        }

        public async Task<Response<ReadMaterialDto>> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Material);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadMaterialDto>("Material is invalid", validationResult.ToErrorResponse());

                var material = _mapper.Map<Material>(request.Material);
                await _materialRepository.Update(material);

                var readMaterial = _mapper.Map<ReadMaterialDto>(material);
                await _unitOfWork.Commit();
                return Response.Ok(readMaterial, "The material was created with success");
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
