using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs;

namespace Ecommerce.Application.Materials.Commands
{
    public record DeleteMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public int MaterialId { get; set; }
    }

    public class DeleteMaterialCommandHandler : IHandlerWrapper<DeleteMaterialCommand, ReadMaterialDto>
    {
        public DeleteMaterialCommandHandler()
        {

        }

        public Task<Response<ReadMaterialDto>> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
