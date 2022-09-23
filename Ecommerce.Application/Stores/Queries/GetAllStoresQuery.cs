using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Stores.Queries
{
    public record GetAllStoresQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadStoreDto>>{}

    public class GetAllStoresQueryHandler : IHandlerWrapper<GetAllStoresQuery, IEnumerable<ReadStoreDto>>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(
            IStoreService storeRepository, 
            IMapper mapper)
        {
            _storeService = storeRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadStoreDto>>> Handle(
            GetAllStoresQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var stores = await _storeService.GetAll(cancellationToken);
                var readStoresDto = _mapper.Map<IEnumerable<ReadStoreDto>>(stores);
                return Response.Ok(readStoresDto, "GetAllStores");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadStoreDto>>($"Fail to get the store. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
