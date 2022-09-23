using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Stores.Commands.CreateStore
{
    public record CreateStoreCommand : BaseRequest, IRequestWrapper<ReadStoreDto>
    {
        public CreateStoreDto Store { get; set; }
    }

    public class CreateStoreCommandHandler : BaseCommand, IHandlerWrapper<CreateStoreCommand, ReadStoreDto>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateStoreValidator _validator;
        public CreateStoreCommandHandler(
            IStoreService storeService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _storeService = storeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new CreateStoreValidator();
        }

        public async Task<Response<ReadStoreDto>> Handle(
            CreateStoreCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.Store);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadStoreDto>("Supplier was not created", validationResult.ToErrorResponse());

                var store = _mapper.Map<Store>(request.Store);
                await _storeService.Add(store, cancellationToken);

                var readStoreDto = _mapper.Map<ReadStoreDto>(store);
                await _unitOfWork.Commit();
                return Response.Ok(readStoreDto, "Supplier created with succes");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                return Response.Fail<ReadStoreDto>($"Fail to create a user. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
