using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Common.Interfaces;

namespace Ecommerce.Application.Operations.Commands.CreateOperation
{
    public record CreateOperationCommand : BaseRequest, IRequestWrapper<ReadOperationDto>
    {
        public CreateOperationDto Operation { get; set; }
    }

    public class CreateOperationCommandHandler : IHandlerWrapper<CreateOperationCommand, ReadOperationDto>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public CreateOperationCommandHandler(
            IOperationRepository operationRepository, 
            IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public Task<Response<ReadOperationDto>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
