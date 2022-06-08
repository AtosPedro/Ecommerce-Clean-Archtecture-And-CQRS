using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Stores.Commands.CreateStoreCommand
{
    public record CreateStoreCommand : BaseRequest, IRequestWrapper<Store>
    {
    }

    public class CreateStoreCommandHandler : IHandlerWrapper<CreateStoreCommand, Store>
    {
        public Task<Response<Store>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
