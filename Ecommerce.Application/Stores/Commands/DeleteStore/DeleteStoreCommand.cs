using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Infrastructure.Services;

namespace Ecommerce.Application.Stores.Commands.DeleteStore
{
    public record DeleteStoreCommand : IRequestWrapper<ReadStoreDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteStoreCommandHandler : IHandlerWrapper<DeleteStoreCommand, ReadStoreDto>
    {
        private readonly IStoreService _storeService;
        public DeleteStoreCommandHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<ReadStoreDto>> Handle(
            DeleteStoreCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var readStoreDto = await _storeService.Delete(request.Guid, cancellationToken);
                return Response.Ok(readStoreDto, "Store deleted with succes");
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadStoreDto>($"Fail to deleted the store. Message: {ex.Message}", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
