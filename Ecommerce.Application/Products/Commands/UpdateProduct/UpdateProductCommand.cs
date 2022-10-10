using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Products.Commands
{
    public record UpdateProductCommand : BaseRequest, IRequestWrapper<ReadProductDto>
    {
        public UpdateProductDto Material { get; set; }
    }

    public class UpdateMaterialCommandHandler : IHandlerWrapper<UpdateProductCommand, ReadProductDto>
    {
        private readonly IProductRepository _materialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateProductValidator _validator;

        public UpdateMaterialCommandHandler(
            IProductRepository materialRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new UpdateProductValidator();
        }

        public async Task<Response<ReadProductDto>> Handle(
            UpdateProductCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Material);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadProductDto>("Material is invalid", validationResult.ToErrorResponse());

                var material = _mapper.Map<Product>(request.Material);
                await _materialRepository.Update(material);

                var readMaterial = _mapper.Map<ReadProductDto>(material);
                await _unitOfWork.Commit();
                return Response.Ok(readMaterial, "The material was created with success");
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = null;

                if (ex is ValidationException)
                {
                    var validationEx = ex as ValidationException;
                    errorResponse = validationEx?.ErrorResponse ?? new ErrorResponse();
                }
                else
                {
                    var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = $"Inner exception: {ex.InnerException}. Message: {ex.Message}" } };
                    errorResponse = new ErrorResponse { Errors = errors };
                }

                await _unitOfWork.RollBack();
                return Response.Fail<ReadProductDto>($"Fail to create a user. Message: {ex.Message}", errorResponse);
            }
        }
    }
}
