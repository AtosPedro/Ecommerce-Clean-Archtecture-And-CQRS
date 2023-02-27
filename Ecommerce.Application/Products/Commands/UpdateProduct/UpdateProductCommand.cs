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
        public UpdateProductDto Product { get; set; }
    }

    public class UpdateProductCommandHandler : IHandlerWrapper<UpdateProductCommand, ReadProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateProductValidator _validator;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
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
                var validationResult = await _validator.ValidateAsync(request.Product);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadProductDto>("Product is invalid", validationResult.ToErrorResponse());

                var product = _mapper.Map<Product>(request.Product);
                await _productRepository.Update(product);

                var readProduct = _mapper.Map<ReadProductDto>(product);
                await _unitOfWork.Commit();
                return Response.Ok(readProduct, "The product was created with success");
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
