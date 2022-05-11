using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetAllSuppliersQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadSupplierDto>>
    {
        public int SupplierId { get; set; }
    }

    public class GetAllSuppliersQueryHandler : IHandlerWrapper<GetAllSuppliersQuery, IEnumerable<ReadSupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadSupplierDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAll();
            var readSuppliers = _mapper.Map<IEnumerable<ReadSupplierDto>>(suppliers);

            return Response.Ok(readSuppliers, "Get Suppliers");
        }
    }
}
