using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Materials.Commands.DeleteMaterial;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.Materials.Commands
{
    public record DeleteMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public DeleteMaterialDto MaterialDto { get; set; }
    }

    public class DeleteMaterialCommandHandler : IHandlerWrapper<DeleteMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeleteMaterialValidator _validator;

        public DeleteMaterialCommandHandler(
            IMaterialRepository materialRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new DeleteMaterialValidator();
        }

        public async Task<Response<ReadMaterialDto>> Handle(
            DeleteMaterialCommand request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var validationResult = await _validator.ValidateAsync(request.MaterialDto);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadMaterialDto>("", validationResult.ToErrorResponse());

                var material = await _materialRepository.GetById(request.MaterialDto.Id);
                await _materialRepository.Remove(material);
              
                var readMaterial = _mapper.Map<ReadMaterialDto>(material);
                await _unitOfWork.Commit();
                return Response.Ok(readMaterial, "Material deleted with succes");
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
