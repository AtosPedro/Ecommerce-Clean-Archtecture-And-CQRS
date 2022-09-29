using AutoMapper;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Repositories;
using HashidsNet;
using System.Threading;

namespace Ecommerce.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IHashids _hashId;
        private readonly IUnitOfWork _unitOfWork;
        public SupplierService(
            ISupplierRepository supplierRepository, 
            IMapper mapper, 
            IHashids hashIds, 
            IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _hashId = hashIds;
            _unitOfWork = unitOfWork;
        }

        #region Queries
        public async Task<ReadSupplierDto> GetById(
            string Guid, 
            CancellationToken cancellationToken)
        {
            try
            {
                var id = _hashId.Decode(Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException("Fronecedor não encontrado");

                var supplier = await _supplierRepository.GetById(id[0], cancellationToken);
                if (supplier == null)
                    throw new NotFoundException("Fronecedor não encontrado");

                supplier.Guid = Guid;
                var readSupplierDtos = _mapper.Map<ReadSupplierDto>(supplier);
                return readSupplierDtos;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ReadSupplierDto>> GetAll(CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAll(cancellationToken);
            foreach (var sup in suppliers)
            {
                sup.Guid = _hashId.Encode(sup.Id);
            }

            var readSupplierDtos = _mapper.Map<IEnumerable<ReadSupplierDto>>(suppliers);
            return readSupplierDtos;
        }

        #endregion

        #region Commands
        public async Task<ReadSupplierDto> Create(
            CreateSupplierDto supplierDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                await _supplierRepository.Add(supplier, cancellationToken);
                await _unitOfWork.Commit();
                supplier.Guid = _hashId.Encode(supplier.Id);

                var readSupplierDto = _mapper.Map<ReadSupplierDto>(supplier);
                return readSupplierDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadSupplierDto> Delete(
            string Guid, 
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var supplier = await _supplierRepository.GetById(id[0], cancellationToken);
                if (supplier == null)
                    throw new NotFoundException();

                var result = await _supplierRepository.Remove(supplier);
                await _unitOfWork.Commit();

                var readSupplierDto = _mapper.Map<ReadSupplierDto>(result);
                return readSupplierDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadSupplierDto> Update(
            UpdateSupplierDto supplierDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(supplierDto.Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var user = await _supplierRepository.GetById(id[0], cancellationToken);
                if (user == null)
                    throw new NotFoundException();

                _mapper.Map(supplierDto, user);
                await _supplierRepository.Update(user);
                await _unitOfWork.Commit();

                var readSupplierDto = _mapper.Map<ReadSupplierDto>(user);
                return readSupplierDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        #endregion
    }
}
