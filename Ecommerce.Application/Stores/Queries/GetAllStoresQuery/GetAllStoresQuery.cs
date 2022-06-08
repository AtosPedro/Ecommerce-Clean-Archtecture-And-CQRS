using Ecommerce.Application.Common.Communication;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Stores.Queries.GetAllStoresQuery
{
    public record GetAllStoresQuery : BaseRequest, IRequestWrapper<Store>
    {
    }

    public class GetAllStoresQueryHandler : IHandlerWrapper<GetAllStoresQuery, Store>
    {
        public Task<Response<Store>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
