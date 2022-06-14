using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Application.OperationalUnits.Commands.DeleteOperationalUnit
{
    public record DeleteOperationalUnitCommand : IRequestWrapper<bool>
    {
        public int OperationalUnitId { get; set; }
    }

    public class DeleteOperationalUnitCommandHandler : IHandlerWrapper<DeleteOperationalUnitCommand, bool>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.OperationalUnitId == 0)
                    throw new InvalidIdException("Invalid Id");

                var operationalUnit = await _operationalUnitRepository.GetById(request.OperationalUnitId);

                if (operationalUnit == null)
                    throw new EntityNotFoundException("The operational unit was not found");

                var success = await _operationalUnitRepository.Remove(operationalUnit);

                await _unitOfWork.Commit();
                return Response.Ok(success != null, "The operational unit was deleted with sucess");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel>{ new ErrorModel { FieldName = "", Message = ex.Message} };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<bool>("The operational unit was not deleted", errorResponse);
            }
        }
    }

}
