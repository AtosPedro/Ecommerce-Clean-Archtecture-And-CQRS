using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Materials.Commands.CreateMaterial;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Exceptions;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Materials.Commands
{
    public record CreateMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto>
    {
        public CreateMaterialDto Material { get; set; }
    }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialService _materialService;
        private readonly CreateMaterialValidator _validator;

        public CreateMaterialCommandHandler(IMaterialService materialService)
        {
            _materialService = materialService;
            _validator = new CreateMaterialValidator();
        }

        public async Task<Response<ReadMaterialDto>> Handle(
            CreateMaterialCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Material);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readMaterial = await _materialService.Create(request.Material, cancellationToken);

                return Response.Ok(readMaterial, "Material created with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadMaterialDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
