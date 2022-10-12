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
        private readonly IProductRepository _productRepository;
        private readonly IHashids _hashId;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository,
            IHashids hashId,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _hashId = hashId;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region Queries
        public async Task<IEnumerable<ReadProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            foreach (var product in products)
            {
                product.Guid = _hashId.Encode(product.Id);
            }
            var readProductsDto = _mapper.Map<IEnumerable<ReadProductDto>>(products);
            return readProductsDto;
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

                var product = await _productRepository.GetById(id[0], cancellationToken);

                if (product != null)
                    product.Guid = guid;
                else
                    throw new NotFoundException();

                var readProductDto = _mapper.Map<ReadProductDto>(product);
                return readProductDto;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Commands
        public async Task<ReadProductDto> Create(
            CreateProductDto createProductDto, 
            CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(createProductDto);
                await _productRepository.Add(product, cancellationToken);
                await _unitOfWork.Commit();
                product.Guid = _hashId.Encode(product.Id);

                var readProductDto = _mapper.Map<ReadProductDto>(product);
                return readProductDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public Task<ReadProductDto> Update(
            UpdateProductDto product, 
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
