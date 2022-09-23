using MediatR;
using Ecommerce.Domain.Entities;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using AutoMapper;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.DTOs.OperationalUnits;

namespace Ecommerce.Application.Materials.Queries
{
    public record GetAllMaterialsQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadMaterialDto>> { }
    public class GetAllMaterialQueryHandler : IHandlerWrapper<GetAllMaterialsQuery, IEnumerable<ReadMaterialDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialQueryHandler(
            IMaterialRepository materialRepository, 
            IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ReadMaterialDto>>> Handle(
            GetAllMaterialsQuery request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var materials = await _materialRepository.GetAll(cancellationToken);
                var readMaterial = _mapper.Map<IEnumerable<ReadMaterialDto>>(materials);
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
