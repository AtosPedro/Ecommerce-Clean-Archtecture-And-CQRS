using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit
{
    public record UpdateOperationalUnitCommand : IRequestWrapper<ReadOperationalUnitDto>
    {
        public UpdateOperationalUnitDto UpdateOperationalUnitDto { get; set; }
    }

    public class UpdateOperationalUnitCommandHandler : IHandlerWrapper<UpdateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        private readonly IOperationalUnitService _operationalUnitService;
        private readonly UpdateOperationalUnitValidator _validator;

        public UpdateOperationalUnitCommandHandler(IOperationalUnitService operationalUnitRepository)
        {
            _operationalUnitService = operationalUnitRepository;
            _validator = new UpdateOperationalUnitValidator();
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(
            UpdateOperationalUnitCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.UpdateOperationalUnitDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readUser = await _operationalUnitService.Update(request.UpdateOperationalUnitDto, cancellationToken);
                return Response.Ok(readUser, "User updated with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadOperationalUnitDto>($"Fail to update the user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
