using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnit;

namespace Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnitCommand
{
    public record CreateOperationalUnitCommand : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public CreateOperationalUnitDto OperationalUnit { get; set; }
    }

    public class CreateOperationalUnitCommandHandler : IHandlerWrapper<CreateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        public Task<Response<ReadOperationalUnitDto>> Handle(CreateOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
