using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Stores.Commands.CreateStore
{
    public record CreateStoreCommand : BaseRequest, IRequestWrapper<ReadStoreDto>
    {
        public CreateStoreDto Store { get; set; }
    }

    public class CreateStoreCommandHandler : BaseCommand, IHandlerWrapper<CreateStoreCommand, ReadStoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        private readonly CreateStoreValidator _validator;
        public CreateStoreCommandHandler(
            IStoreRepository storeRepository,
            IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _validator = new CreateStoreValidator();
        }

        public async Task<Response<ReadStoreDto>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Store);
                if (!validationResult.IsValid)
                {
                    var errorResponse = ErrorResponse.ToErrorResponse(validationResult);
                    return Response.Fail<ReadStoreDto>("Supplier was not created", errorResponse);
                }

                var store = _mapper.Map<CreateStoreDto, Store>(request.Store);
                var createdStore = await _storeRepository.Add(store);
                var readStoreDto = _mapper.Map<ReadStoreDto>(createdStore);
                
                return Response.Ok(readStoreDto, "Supplier created with succes");
            }
            catch
            {
                throw;
            }
        }
    }
}
