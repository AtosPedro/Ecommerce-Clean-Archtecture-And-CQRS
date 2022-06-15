using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;

namespace Ecommerce.Application.Operations.Commands.UpdateOperation
{
    public record UpdateOperationCommand : IRequestWrapper<ReadOperationDto>
    {
        public ReadOperationDto Operation { get; set; }
    }

    public class UpdateOperationCommandHandler : IHandlerWrapper<UpdateOperationCommand, ReadOperationDto>
    {
        public Task<Response<ReadOperationDto>> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
