using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetAllSuppliersQuery : BaseRequest, IRequestWrapper<IEnumerable<Supplier>>{}

    public class GetAllSuppliersQueryHandler : IHandlerWrapper<GetAllSuppliersQuery, IEnumerable<Supplier>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<Supplier>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAll();
            return Response.Ok(suppliers, "Get Suppliers");
        }
    }
}
