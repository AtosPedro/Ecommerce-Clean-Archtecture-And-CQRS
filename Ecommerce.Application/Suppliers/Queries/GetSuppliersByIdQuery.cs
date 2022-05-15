using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetSuppliersByIdQuery : IRequestWrapper<ReadSupplierDto>{}

    public class GetSuppliersByIdQueryHandler : IHandlerWrapper<GetSuppliersByIdQuery, ReadSupplierDto>
    {
        public Task<Response<ReadSupplierDto>> Handle(GetSuppliersByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
