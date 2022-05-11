using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs;

namespace Ecommerce.Application.Materials.Commands
{
    public record UpdateMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public UpdateMaterialDto Material { get; set; }
    }

    public class UpdateMaterialCommandHandler : IHandlerWrapper<UpdateMaterialCommand, ReadMaterialDto>
    {
        public Task<Response<ReadMaterialDto>> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
