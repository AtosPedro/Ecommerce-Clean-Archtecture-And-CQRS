using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record DeleteSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public int SupplierId { get; set; }
    }

    public class DeleteSupplierCommandHandler : IHandlerWrapper<DeleteSupplierCommand, ReadSupplierDto>
    {
        public Task<Response<ReadSupplierDto>> Handle(
            DeleteSupplierCommand request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
