using AutoMapper;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class OperationalUnitService : IOperationalUnitService
    {
        private readonly IOperationalUnitRepository _operationalUnitRepository;
        private readonly IHashids _hashId;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OperationalUnitService(
            IOperationalUnitRepository operationalUnitRepository,
            IHashids hashId,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _operationalUnitRepository = operationalUnitRepository;
            _hashId = hashId;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReadOperationalUnitDto> Create(
            CreateOperationalUnitDto operationalUnitDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                var operationalUnit = _mapper.Map<OperationalUnit>(operationalUnitDto);
                await _operationalUnitRepository.Add(operationalUnit, cancellationToken);
                await _unitOfWork.Commit();
                operationalUnit.Guid = _hashId.Encode(operationalUnit.Id);

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(operationalUnit);
                return readOperationalUnitDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadOperationalUnitDto> Delete(string guid, CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var operationalUnit = await _operationalUnitRepository.GetById(id[0], cancellationToken);
                if (operationalUnit == null)
                    throw new NotFoundException();

                var result = await _operationalUnitRepository.Remove(operationalUnit);
                await _unitOfWork.Commit();

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(result);
                return readOperationalUnitDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<IEnumerable<ReadOperationalUnitDto>> GetAll(CancellationToken cancellationToken)
        {
            var operationalUnits = await _operationalUnitRepository.GetAll(cancellationToken);
            foreach (var user in operationalUnits)
            {
                user.Guid = _hashId.Encode(user.Id);
            }
            var readOperationalUnitsDto = _mapper.Map<IEnumerable<ReadOperationalUnitDto>>(operationalUnits);
            return readOperationalUnitsDto;
        }

        public async Task<ReadOperationalUnitDto> GetById(string guid, CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var operationalUnit = await _operationalUnitRepository.GetById(id[0], cancellationToken);

                if (operationalUnit != null)
                    operationalUnit.Guid = guid;
                else
                    throw new NotFoundException();

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(operationalUnit);
                return readOperationalUnitDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReadOperationalUnitDto> Update(
            UpdateOperationalUnitDto operationalUnitDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(operationalUnitDto.Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var operationalUnit = await _operationalUnitRepository.GetById(id[0], cancellationToken);
                if (operationalUnit == null)
                    throw new NotFoundException();

                _mapper.Map(operationalUnitDto, operationalUnit);
                await _operationalUnitRepository.Update(operationalUnit);
                await _unitOfWork.Commit();

                var readOperationalUnitDto = _mapper.Map<ReadOperationalUnitDto>(operationalUnit);
                return readOperationalUnitDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
