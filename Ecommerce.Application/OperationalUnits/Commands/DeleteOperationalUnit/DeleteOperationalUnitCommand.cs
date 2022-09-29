using Ecommerce.Application.Common.Communication;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.OperationalUnits.Commands.DeleteOperationalUnit
{
    public record DeleteOperationalUnitCommand : IRequestWrapper<bool>
    {
        public string Guid { get; set; }
    }

    public class DeleteOperationalUnitCommandHandler : IHandlerWrapper<DeleteOperationalUnitCommand, bool>
    {
        private readonly IOperationalUnitService _operationalUnitRepository;

        public DeleteOperationalUnitCommandHandler(IOperationalUnitService operationalUnitRepository)
        {
            _operationalUnitRepository = operationalUnitRepository;
        }

        public async Task<Response<bool>> Handle(DeleteOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var readUser = await _operationalUnitRepository.Delete(request.Guid, cancellationToken);
                return Response.Ok(true, "Operational Unit deleted with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<bool>($"Fail to deleted the operational unit. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
