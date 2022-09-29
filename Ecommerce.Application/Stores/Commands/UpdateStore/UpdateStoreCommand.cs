using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Stores.Commands.UpdateStore
{
    public record UpdateStoreCommand : BaseRequest, IRequestWrapper<ReadStoreDto>
    {
        public UpdateStoreDto UpdateStoreDto { get; set; }
    }

    public class UpdateStoreCommandHandler : IHandlerWrapper<UpdateStoreCommand, ReadStoreDto>
    {
        private readonly IStoreService _storeService;
        private readonly UpdateStoreValidator _validator;
        public UpdateStoreCommandHandler(IStoreService storeService)
        {
            _storeService = storeService;
            _validator = new UpdateStoreValidator();
        }

        public async Task<Response<ReadStoreDto>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.UpdateStoreDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.ToErrorResponse());

                var readUser = await _storeService.Update(request.UpdateStoreDto, cancellationToken);
                return Response.Ok(readUser, "Supplier updated with succes");
            }
            catch (Exception ex)
            {
                Response.Fail<ReadStoreDto>("", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
