using AutoMapper;
using Ecommerce.Application.Common.DTOs.Materials;
using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using HashidsNet;
using System;
using System.Threading;

namespace Ecommerce.Infrastructure.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IHashids _hashId;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(
            IMaterialRepository materialRepository,
            IHashids hashId,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _hashId = hashId;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region Queries
        public async Task<IEnumerable<ReadMaterialDto>> GetAll(CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetAll(cancellationToken);
            foreach (var material in materials)
            {
                material.Guid = _hashId.Encode(material.Id); ;
                material.StoreGuid = _hashId.Encode(material.StoreId);
                material.SupplierGuid = _hashId.Encode(material.SupplierId);
            }
            var readMaterialsDto = _mapper.Map<IEnumerable<ReadMaterialDto>>(materials);
            return readMaterialsDto;
        }

        public async Task<ReadMaterialDto> GetById(
            string guid, 
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var material = await _materialRepository.GetById(id[0], cancellationToken);

                if (material != null)
                {
                    material.Guid = guid;
                    material.StoreGuid = _hashId.Encode(material.StoreId);
                    material.SupplierGuid = _hashId.Encode(material.SupplierId);
                }
                else
                    throw new NotFoundException();

                var readMaterialDto = _mapper.Map<ReadMaterialDto>(material);
                return readMaterialDto;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Commands
        public async Task<ReadMaterialDto> Create(
            CreateMaterialDto createMaterialDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                var material = _mapper.Map<Material>(createMaterialDto);
                material.StoreId = _hashId.Decode(createMaterialDto.StoreGuid)[0];
                await _materialRepository.Add(material, cancellationToken);
                await _unitOfWork.Commit();
                material.Guid = _hashId.Encode(material.Id);

                var readMaterialDto = _mapper.Map<ReadMaterialDto>(material);
                return readMaterialDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public Task<ReadMaterialDto> Update(
            UpdateMaterialDto material, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ReadMaterialDto> Delete(
            string guid, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
