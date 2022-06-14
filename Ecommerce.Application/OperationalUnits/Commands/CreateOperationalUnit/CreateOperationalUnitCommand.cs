﻿using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Extensions;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnit
{
    public record CreateOperationalUnitCommand : BaseRequest, IRequestWrapper<ReadOperationalUnitDto>
    {
        public CreateOperationalUnitDto OperationalUnit { get; set; }
    }

    public class CreateOperationalUnitCommandHandler : IHandlerWrapper<CreateOperationalUnitCommand, ReadOperationalUnitDto>
    {
        private readonly CreateOperationalUnitValidator _validator;
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOperationalUnitCommandHandler(
            IOperationalUnitRepository operationalUnitRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _validator = new CreateOperationalUnitValidator();
            _operationalUnitRepository = operationalUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ReadOperationalUnitDto>> Handle(CreateOperationalUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request.OperationalUnit);
                if (!validationResult.IsValid)
                    return Response.Fail<ReadOperationalUnitDto>("The operational unit was not created", validationResult.ToErrorResponse());

                var operationalUnit = _mapper.Map<OperationalUnit>(request.OperationalUnit);
                
                var createdOperationalUnit = await _operationalUnitRepository.Add(operationalUnit);
                if (createdOperationalUnit == null)
                    return Response.Fail<ReadOperationalUnitDto>("The operational unit was not created", null);

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(createdOperationalUnit);

                await _unitOfWork.Commit();
                return Response.Ok(readOperationalUnitDto, "The operational unit was not created");
            }
            catch (Exception ex)
            {
                var errors = new List<ErrorModel> { new ErrorModel { FieldName = "", Message = ex.Message } };
                var errorResponse = new ErrorResponse { Errors = errors };

                await _unitOfWork.RollBack();
                return Response.Fail<ReadOperationalUnitDto>("The operational unit was not created", errorResponse);
            }
        }
    }
}
