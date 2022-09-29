using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Suppliers.Commands.UpdateSupplier;
using Ecommerce.Application.Users.Commands.UpdateUser;

namespace Ecommerce.Application.Suppliers.Commands
{
    public record UpdateSupplierCommand : IRequestWrapper<ReadSupplierDto>
    {
        public UpdateSupplierDto UpdateSupplierDto { get; set; }
    }

    public class UpdateSupplierCommandHandler : IHandlerWrapper<UpdateSupplierCommand, ReadSupplierDto>
    {
        private readonly ISupplierService _supplierService;
        private readonly UpdateSupplierValidator _validator;
        public UpdateSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _validator = new UpdateSupplierValidator();
        }

        public async Task<Response<ReadSupplierDto>> Handle(
            UpdateSupplierCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.UpdateSupplierDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readUser = await _supplierService.Update(request.UpdateSupplierDto, cancellationToken);
                return Response.Ok(readUser, "Supplier updated with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadSupplierDto>($"Fail to update the supplier. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
