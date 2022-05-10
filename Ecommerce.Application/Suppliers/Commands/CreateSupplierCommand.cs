using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Suppliers.Commands
{
    public class CreateSupplierCommand : IRequestWrapper<Supplier>{}
    public class CreateSupplierCommandHandler : IHandlerWrapper<CreateSupplierCommand, Supplier>
    {
        private readonly ISupplierRepository _supplierRepository;
        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }


        public Task<Response<Supplier>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
