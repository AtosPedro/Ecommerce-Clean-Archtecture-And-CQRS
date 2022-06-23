using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record UpdateSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public UpdateSupplierDto Supplier { get; set; }
        public int SupplierId { get; set; }
    }

    public class UpdateSupplierCommandHandler : IHandlerWrapper<UpdateSupplierCommand, ReadSupplierDto>
    {
        public Task<Response<ReadSupplierDto>> Handle(
            UpdateSupplierCommand request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
