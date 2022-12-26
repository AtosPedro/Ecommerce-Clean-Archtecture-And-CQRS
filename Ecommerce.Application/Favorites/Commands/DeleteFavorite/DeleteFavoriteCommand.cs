using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Favorites.Commands.DeleteFavorite
{
    public record DeleteFavoriteCommand : BaseRequest, IRequestWrapper<ReadOrderDto>
    {
        public string Guid { get; set; }
    }

    public class DeleteFavoriteCommandHandler : IHandlerWrapper<DeleteFavoriteCommand, ReadOrderDto>
    {
        public DeleteFavoriteCommandHandler()
        {

        }

        public async Task<Response<ReadOrderDto>> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return Response.Fail<ReadOrderDto>("Command Failed", ErrorHandler.HandleApplicationError(ex));
            }
        }
    }

}
