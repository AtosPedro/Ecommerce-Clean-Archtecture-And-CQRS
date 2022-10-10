using AutoMapper;
using Ecommerce.Application.Common.DTOs.Products;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services 
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _materialRepository;
        private readonly IHashids _hashId;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository materialRepository,
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
        public async Task<IEnumerable<ReadProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetAll(cancellationToken);
            foreach (var material in materials)
            {
                material.Guid = _hashId.Encode(material.Id); ;
            }
            var readMaterialsDto = _mapper.Map<IEnumerable<ReadProductDto>>(materials);
            return readMaterialsDto;
        }

        public async Task<ReadProductDto> GetById(
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
                }
                else
                    throw new NotFoundException();

                var readMaterialDto = _mapper.Map<ReadProductDto>(material);
                return readMaterialDto;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Commands
        public async Task<ReadProductDto> Create(
            CreateProductDto createMaterialDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                var material = _mapper.Map<Product>(createMaterialDto);
                await _materialRepository.Add(material, cancellationToken);
                await _unitOfWork.Commit();
                material.Guid = _hashId.Encode(material.Id);

                var readMaterialDto = _mapper.Map<ReadProductDto>(material);
                return readMaterialDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public Task<ReadProductDto> Update(
            UpdateProductDto material, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ReadProductDto> Delete(
            string guid, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
