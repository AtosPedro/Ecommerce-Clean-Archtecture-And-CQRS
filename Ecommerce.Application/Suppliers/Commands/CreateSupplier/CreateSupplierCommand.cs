using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Suppliers.Commands.CreateSupplier;
using Ecommerce.Application.Common.Extensions;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record CreateSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public CreateSupplierDto Supplier { get; set; }
    }

    public class CreateSupplierCommandHandler : IHandlerWrapper<CreateSupplierCommand, ReadSupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateSupplierValidator _validator;

        public CreateSupplierCommandHandler(
            ISupplierRepository supplierRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new CreateSupplierValidator();
        }

        public async Task<Response<ReadSupplierDto>> Handle(
            CreateSupplierCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Supplier);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadSupplierDto>("The supplier is invalid", validationResult.ToErrorResponse());

                var supplier = _mapper.Map<CreateSupplierDto, Supplier>(request.Supplier);
                await _supplierRepository.Add(supplier);

                var readSupplierDto = _mapper.Map<ReadSupplierDto>(supplier);
                await _unitOfWork.Commit();
                return Response.Ok(readSupplierDto, "Supplier created with succes");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<ReadSupplierDto>("", errorResponse);
            }

        }
    }

}
