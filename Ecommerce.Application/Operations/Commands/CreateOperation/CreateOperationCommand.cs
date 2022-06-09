using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;

namespace Ecommerce.Application.Operations.Commands.CreateOperation
{
    public record CreateOperationCommand : BaseRequest, IRequestWrapper<ReadOperationDto>
    {
        public CreateOperationDto Operation { get; set; }
    }

    public class CreateOperationCommandHandler : IHandlerWrapper<CreateOperationCommand, ReadOperationDto>
    {
        public Task<Response<ReadOperationDto>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
