using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.OperationalUnits.Commands.DeleteOperationalUnit
{
    public record DeleteOperationalUnitCommand : IRequestWrapper<bool>
    {
        public int OperationalUnitId { get; set; }
    }

    public class DeleteOperationalUnitCommandHandler : IHandlerWrapper<DeleteOperationalUnitCommand, bool>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.OperationalUnitId == 0)
                {
                    var errors = new List<ErrorModel> 
                    {
                        new ErrorModel { FieldName = "OperationalUnitId", Message = "Invalid operational unit id"}
                    };

                    return Response.Fail<bool>("The operational unit was not deleted", new ErrorResponse { Errors = errors });
                }

                var operationalUnit = await _operationalUnitRepository.GetById(request.OperationalUnitId);
                var success = await _operationalUnitRepository.Remove(operationalUnit);

                await _unitOfWork.Commit();
                return Response.Ok(success != null, "The operational unit was deleted with sucess");
            }
            catch
            {
                await _unitOfWork.RollBack();
                return Response.Fail<bool>("The operational unit was not deleted", null);
            }
        }
    }

}
