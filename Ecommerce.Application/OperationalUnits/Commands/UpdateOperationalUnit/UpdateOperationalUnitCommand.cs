using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit
{
    public record UpdateOperationalUnitCommand : IRequestWrapper<ReadOperationalUnitDto>
    {
        public UpdateOperationalUnitDto OperationalUnit { get; set; }
    }

    public class UpdateOperationalUnitCommandHandler : IHandlerWrapper<UpdateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateOperationalUnitValidator _validator;

        public UpdateOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new UpdateOperationalUnitValidator();
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(UpdateOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResponse = await _validator.ValidateAsync(request.OperationalUnit);
                if (!validationResponse.IsValid)
                    return Response.Fail<ReadOperationalUnitDto>("The operational unit is invalid", validationResponse.ToErrorResponse());

                var operationalUnit = _mapper.Map<OperationalUnit>(request.OperationalUnit);
                await _operationalUnitRepository.Update(operationalUnit);

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(operationalUnit);
                await _unitOfWork.Commit();
                return Response.Ok(readOperationalUnitDto, "The operational unit was not created");
            }
            catch(Exception ex)
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
                return Response.Fail<ReadOperationalUnitDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
