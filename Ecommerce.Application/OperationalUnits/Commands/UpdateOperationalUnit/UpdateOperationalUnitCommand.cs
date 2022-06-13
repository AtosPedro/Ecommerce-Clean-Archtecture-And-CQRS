using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit
{
    public record UpdateOperationalUnitCommand : IRequestWrapper<ReadOperationalUnitDto>
    {
        public UpdateOperationalUnitDto OperationalUnit { get; set; }
    }

    public class UpdateOperationalUnitCommandHandler : IHandlerWrapper<UpdateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateOperationalUnitValidator _validator;

        public UpdateOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new UpdateOperationalUnitValidator();
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(UpdateOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResponse = await _validator.ValidateAsync(request.OperationalUnit);
                if (!validationResponse.IsValid)
                    return Response.Fail<ReadOperationalUnitDto>("The operational unit was not created", validationResponse.ToErrorResponse());

                var operationalUnit = _mapper.Map<OperationalUnit>(request.OperationalUnit);

                var updatedOperationalUnit = await _operationalUnitRepository.Update(operationalUnit);
                if (updatedOperationalUnit == null)
                    throw new Exception();

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(updatedOperationalUnit);
                
                await _unitOfWork.Commit();
                return Response.Ok(readOperationalUnitDto, "The operational unit was not created");
            }
            catch
            {
                await _unitOfWork.RollBack();
                return Response.Fail<ReadOperationalUnitDto>("The operational unit was not created", null);
            }
        }
    }
}
