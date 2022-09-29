using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetSupplierByIdQuery : IRequestWrapper<ReadSupplierDto>
    {
        public string Guid { get; set; }
    }

    public class GetSupplierByIdQueryHandler : IHandlerWrapper<GetSupplierByIdQuery, ReadSupplierDto>
    {
        private readonly ISupplierService _supplierService;
        public GetSupplierByIdQueryHandler(ISupplierService supplierServiceç)
        {
            _supplierService = supplierServiceç;
        }

        public async Task<Response<ReadSupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var readUser = await _supplierService.GetById(request.Guid, cancellationToken);
                return Response.Ok(readUser, "Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadSupplierDto>($"Fail to get the supplier. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
