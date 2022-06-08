using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Stores.Queries.GetAllStoresQuery
{
    public record GetAllStoresQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadStoreDto>>
    {
    }

    public class GetAllStoresQueryHandler : IHandlerWrapper<GetAllStoresQuery, IEnumerable<ReadStoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadStoreDto>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetAll();
            var readStoresDto =  _mapper.Map<IEnumerable<ReadStoreDto>>(stores);

            return Response.Ok(readStoresDto, "GetAllStores");
        }
    }
}
