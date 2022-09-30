using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Infrastructure.Services;
using AutoMapper;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetAllMaterialsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadMaterialDto>> { }
    public class GetAllMaterialQueryHandler : IHandlerWrapper<GetAllMaterialsQuery, IEnumerable<ReadMaterialDto>>
    {
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;

        public GetAllMaterialQueryHandler(
            IMaterialService materialRepository, 
            IMapper mapper)
        {
            _materialService = materialRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ReadMaterialDto>>> Handle(
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
                return Response.Fail<IEnumerable<ReadMaterialDto>>(
                    $"Fail to create a user. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
