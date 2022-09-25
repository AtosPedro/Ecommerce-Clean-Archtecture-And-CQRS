using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Exceptions;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Stores.Queries
{
    public record GetStoreByIdQuery : BaseRequest, IRequestWrapper<ReadStoreDto>
    {
        public string Guid { get; set; }
    }

    public class GetStoreByIdQueryHandler : IHandlerWrapper<GetStoreByIdQuery, ReadStoreDto>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public GetStoreByIdQueryHandler(
            IStoreService storeService, 
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<Response<ReadStoreDto>> Handle(
            GetStoreByIdQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var store = await _storeService.GetById(request.Guid, cancellationToken);
                if (store == null)
                    throw new NotFoundException("Store not found!");

                var readUsers = _mapper.Map<ReadStoreDto>(store);
                readUsers.Guid = request.Guid;

                return Response.Ok(readUsers, "Get all stores");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadStoreDto>($"Fail to get the store. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
