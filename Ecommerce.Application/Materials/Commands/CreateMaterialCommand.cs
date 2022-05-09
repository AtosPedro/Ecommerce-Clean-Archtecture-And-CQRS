using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Materials.DTOs;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Materials.Commands
{
    public class CreateMaterialCommand : BaseRequest, IRequestWrapper<ReadMaterialDto> 
    {
        public CreateMaterialDto Material { get; set; }
        public ReadMaterialDto ReadMaterialDto { get; set; }
    }
    public class CreateMaterialCommandHandler : IHandlerWrapper<CreateMaterialCommand, ReadMaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;
        public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public Task<Response<ReadMaterialDto>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
