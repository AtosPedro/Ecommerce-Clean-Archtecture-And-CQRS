using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnit
{
    public record CreateOperationalUnitCommand : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public CreateOperationalUnitDto CreateOperationalUnitDto { get; set; }
    }

    public class CreateOperationalUnitCommandHandler : IHandlerWrapper<CreateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        private readonly CreateOperationalUnitValidator _validator;
        private readonly IOperationalUnitService _operationalUnitService;

        public CreateOperationalUnitCommandHandler(IOperationalUnitService operationalUnitRepository)
        {
            _validator = new CreateOperationalUnitValidator();
            _operationalUnitService = operationalUnitRepository;
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(
            CreateOperationalUnitCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.CreateOperationalUnitDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readUserDto = await _operationalUnitService.Create(request.CreateOperationalUnitDto, cancellationToken);

                return Response.Ok(readUserDto, "User created with success");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadOperationalUnitDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
