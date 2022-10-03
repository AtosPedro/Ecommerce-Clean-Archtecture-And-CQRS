using AutoMapper;
using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IHashids _hashId;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        public StoreService(
            IStoreRepository storeRepository,
            IHashids hashId,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
        {
            _storeRepository = storeRepository;
            _hashId = hashId;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        #region Queries

        public async Task<IEnumerable<ReadStoreDto>> GetAll(CancellationToken cancellationToken)
        {
            var stores = new List<Store>();
            var cachedStores = await _cacheService.GetManyCacheValueAsync<Store>();
            if (cachedStores == null || !cachedStores.Any())
                stores = (await _storeRepository.GetAll(cancellationToken)).ToList();
            else
                stores = cachedStores.ToList();

            foreach (var sto in stores)
            {
                sto.Guid = _hashId.Encode(sto.Id);
                var cachedStore = await _cacheService.GetCacheValueAsync<Store>(sto.Guid);
                if (cachedStore == null)
                {
                    await _cacheService.SetCacheValueAsync(sto.Guid, sto);
                }
            }

            var readStoresDtos = _mapper.Map<IEnumerable<ReadStoreDto>>(stores);
            return readStoresDtos;
        }

        public async Task<ReadStoreDto> GetById(
            string guid,
            CancellationToken cancellationToken)
        {
            try
            {
                var id = _hashId.Decode(guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException("Loja não encontrado");

                Store store = null;
                var storeCached = await _cacheService.GetCacheValueAsync<Store>(guid);
                if (storeCached == null)
                    store = await _storeRepository.GetById(id[0], cancellationToken);
                else
                    store = storeCached;

                if (store == null && storeCached == null)
                    throw new NotFoundException("Loja não encontrado");

                store.Guid = guid;
                bool successCached = false;
                if (storeCached == null)
                    successCached = await _cacheService.SetCacheValueAsync(store.Guid, store);

                var readStoreDtos = _mapper.Map<ReadStoreDto>(store);
                return readStoreDtos;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Commands

        public async Task<ReadStoreDto> Create(
            CreateStoreDto createStoreDto,
            CancellationToken cancellationToken)
        {
            try
            {
                var store = _mapper.Map<Store>(createStoreDto);
                await _storeRepository.Add(store, cancellationToken);
                await _unitOfWork.Commit();
                store.Guid = _hashId.Encode(store.Id);
                await _cacheService.SetCacheValueAsync(store.Guid, store);

                var readStoreDto = _mapper.Map<ReadStoreDto>(store);
                return readStoreDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadStoreDto> Update(
            UpdateStoreDto updateStoreDto,
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(updateStoreDto.Guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var store = await _storeRepository.GetById(id[0], cancellationToken);
                if (store == null)
                    throw new NotFoundException();

                _mapper.Map(updateStoreDto, store);
                await _storeRepository.Update(store);
                await _unitOfWork.Commit();

                await _cacheService.SetCacheValueAsync(store.Guid, store);

                var readStoreDto = _mapper.Map<ReadStoreDto>(store);
                return readStoreDto;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }

        public async Task<ReadStoreDto> Delete(
            string guid,
            CancellationToken cancellationToken)
        {
            try
            {
                int[] id = _hashId.Decode(guid);
                if (id == null || id.Length == 0)
                    throw new NotFoundException();

                var store = await _storeRepository.GetById(id[0], cancellationToken);
                if (store == null)
                    throw new NotFoundException();

                var result = await _storeRepository.Remove(store);
                await _unitOfWork.Commit();
                await _cacheService.RemoveCacheValueAsync<Store>(guid);

                var readStoreDto = _mapper.Map<ReadStoreDto>(result);
                return readStoreDto;
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
