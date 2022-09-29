using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetAllSuppliersQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadSupplierDto>>{}

    public class GetAllSuppliersQueryHandler : IHandlerWrapper<GetAllSuppliersQuery, IEnumerable<ReadSupplierDto>>
    {
        private readonly ISupplierService _supplierService;

        public GetAllSuppliersQueryHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<Response<IEnumerable<ReadSupplierDto>>> Handle(
            GetAllSuppliersQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var readSuppliers = await _supplierService.GetAll(cancellationToken);
                return Response.Ok(readSuppliers, "Get Suppliers");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadSupplierDto>>(
                    $"Fail to get the suppliers. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
