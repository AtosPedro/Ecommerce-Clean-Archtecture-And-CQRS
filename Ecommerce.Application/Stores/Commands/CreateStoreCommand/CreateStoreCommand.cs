using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Stores.Commands.CreateStoreCommand
{
    public record CreateStoreCommand : BaseRequest, IRequestWrapper<ReadStoreDto>
    {
        public CreateStoreDto Store { get; set; }
    }

    public class CreateStoreCommandHandler : IHandlerWrapper<CreateStoreCommand, ReadStoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<Response<ReadStoreDto>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = _mapper.Map<CreateStoreDto, Store>(request.Store);
            var createdStore = await _storeRepository.Add(store);

            if (createdStore != null)
            {
                var readStoreDto = _mapper.Map<ReadStoreDto>(createdStore);
                return Response.Ok(readStoreDto, "Supplier created with succes");
            }
            else
            {
                return Response.Fail<ReadStoreDto>("Supplier was not created", null);
            }
        }
    }
}
