using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Suppliers;

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
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierCommandHandler(
            ISupplierRepository supplierRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Supplier>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = _mapper.Map<CreateSupplierDto, Supplier>(request.Supplier);

                var createdSupplier = await _supplierRepository.Add(supplier);
                if (createdSupplier == null)
                    return Response.Fail<Supplier>("Supplier was not created", null);
                
                await _unitOfWork.Commit();
                return Response.Ok(createdSupplier, "Supplier created with succes");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<Supplier>("", errorResponse);
            }

        }
    }

}
