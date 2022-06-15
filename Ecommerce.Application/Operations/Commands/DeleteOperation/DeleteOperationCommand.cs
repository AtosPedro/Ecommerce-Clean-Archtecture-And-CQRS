using Ecommerce.Application.Common.Communication;

namespace Ecommerce.Application.Operations.Commands.DeleteOperation
{
    public record DeleteOperationCommand : IRequestWrapper<bool>
    {
        public int OperationId { get; set; }
    }

    class DeleteOperationCommandHandler : IHandlerWrapper<DeleteOperationCommand, bool>
    {
        public Task<Response<bool>> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
