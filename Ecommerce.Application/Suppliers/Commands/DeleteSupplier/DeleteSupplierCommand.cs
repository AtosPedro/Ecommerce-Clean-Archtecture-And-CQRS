using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record DeleteSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteSupplierCommandHandler : IHandlerWrapper<DeleteSupplierCommand, ReadSupplierDto>
    {
        private readonly ISupplierService _supplierService;
        public DeleteSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<Response<ReadSupplierDto>> Handle(
            DeleteSupplierCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var readUser = await _supplierService.Delete(request.Guid, cancellationToken);
                return Response.Ok(readUser, "Supplier deleted with success.");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadSupplierDto>($"Fail to deleted the supplier. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
