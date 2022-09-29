using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Suppliers.Commands.CreateSupplier;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record CreateSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public CreateSupplierDto Supplier { get; set; }
    }

    public class CreateSupplierCommandHandler : IHandlerWrapper<CreateSupplierCommand, ReadSupplierDto>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateSupplierValidator _validator;

        public CreateSupplierCommandHandler(
            ISupplierService supplierService, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _supplierService = supplierService;
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
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readSupplierDto = await _supplierService.Create(request.Supplier, cancellationToken);

                return Response.Ok(readSupplierDto, "Supplier created with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadSupplierDto>($"Fail to create a supplier. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex)); ;
            }

        }
    }

}
