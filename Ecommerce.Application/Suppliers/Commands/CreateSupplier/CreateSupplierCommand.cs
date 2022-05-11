using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Common.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record CreateSupplierCommand : IRequestWrapper<Supplier>
    {
        public CreateSupplierDto Supplier { get; set; }
    }

    public class CreateSupplierCommandHandler : IHandlerWrapper<CreateSupplierCommand, Supplier>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Response<Supplier>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<CreateSupplierDto, Supplier>(request.Supplier);
            var createdSupplier = await _supplierRepository.Add(supplier);

            if (createdSupplier != null)
                return Response.Ok(createdSupplier, "Supplier created with succes");
            else
                return Response.Fail<Supplier>("Supplier was not created", null);
        }
    }

}
