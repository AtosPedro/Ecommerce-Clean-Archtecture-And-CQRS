using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;

namespace Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit
{
    public record UpdateOperationalUnitCommand : IRequestWrapper<ReadOperationalUnitDto>
    {
        public UpdateOperationalUnitDto OperationalUnit { get; set; }
    }

    public class UpdateOperationalUnitCommandHandler : IHandlerWrapper<UpdateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        public Task<Response<ReadOperationalUnitDto>> Handle(UpdateOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
