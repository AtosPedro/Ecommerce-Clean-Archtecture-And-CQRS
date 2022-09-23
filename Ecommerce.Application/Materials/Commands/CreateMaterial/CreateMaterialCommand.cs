using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Materials.Commands.CreateMaterial;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Exceptions;

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
        private readonly CreateMaterialValidator _validator;

        public CreateMaterialCommandHandler(
            IMaterialRepository materialRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new CreateMaterialValidator();
        }

        public async Task<Response<ReadMaterialDto>> Handle(
            CreateMaterialCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Material);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadMaterialDto>("Material is invalid", validationResult.ToErrorResponse());

                var material = _mapper.Map<Material>(request.Material);
                await _materialRepository.Add(material, cancellationToken);

                var readMaterial = _mapper.Map<ReadMaterialDto>(material);
                await _unitOfWork.Commit();
                return Response.Ok(readMaterial, "Material created with succes");
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = null;

                if (ex is ValidationException)
                {
                    var validationEx = ex as ValidationException;
                    errorResponse = validationEx?.ErrorResponse ?? new ErrorResponse();
                }
                else
                {
                    var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = $"Inner exception: {ex.InnerException}. Message: {ex.Message}" } };
                    errorResponse = new ErrorResponse { Errors = errors };
                }

                await _unitOfWork.RollBack();
                return Response.Fail<ReadMaterialDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }

}
