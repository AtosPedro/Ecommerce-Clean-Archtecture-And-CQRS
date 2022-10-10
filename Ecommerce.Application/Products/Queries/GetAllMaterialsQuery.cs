using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Infrastructure.Services;
using AutoMapper;
using Ecommerce.Application.Common.DTOs.Products;

namespace Ecommerce.Application.Products.Queries
{
    public record GetAllMaterialsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadProductDto>> { }
    public class GetAllMaterialQueryHandler : IHandlerWrapper<GetAllMaterialsQuery, IEnumerable<ReadProductDto>>
    {
        private readonly IProductService _materialService;
        private readonly IMapper _mapper;

        public GetAllMaterialQueryHandler(
            IProductService materialRepository, 
            IMapper mapper)
        {
            _materialService = materialRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ReadProductDto>>> Handle(
            GetAllMaterialsQuery request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var readMaterial = await _materialService.GetAll(cancellationToken);
                return Response.Ok(readMaterial, "");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadProductDto>>(
                    $"Fail to create a user. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
