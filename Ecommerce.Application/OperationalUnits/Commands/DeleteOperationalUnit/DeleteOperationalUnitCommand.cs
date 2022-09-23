using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.OperationalUnits.Commands.DeleteOperationalUnit
{
    public record DeleteOperationalUnitCommand : IRequestWrapper<bool>
    {
        public DeleteOperationalUnitDto OperationalUnitDto { get; set; }
    }

    public class DeleteOperationalUnitCommandHandler : IHandlerWrapper<DeleteOperationalUnitCommand, bool>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeleteOperationalUnitValidator _validator;

        public DeleteOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _unitOfWork = unitOfWork;
            _validator = new DeleteOperationalUnitValidator();
        }

        public async Task<Response<bool>> Handle(DeleteOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.OperationalUnitDto);
                if (!validationResult.IsValid)
                    return Response.Fail<bool>("The operational unit is invalid", validationResult.ToErrorResponse());

                var operationalUnit = await _operationalUnitRepository.GetById(request.OperationalUnitDto.Id,cancellationToken);
                var success = await _operationalUnitRepository.Remove(operationalUnit);

                await _unitOfWork.Commit();
                return Response.Ok(success != null, "The operational unit was deleted with sucess");
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
                return Response.Fail<bool>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }

}
