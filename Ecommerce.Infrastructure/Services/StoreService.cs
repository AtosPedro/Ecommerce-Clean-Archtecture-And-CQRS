using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IHashids _hashId;
        public StoreService(IStoreRepository storeRepository, IHashids hashId)
        {
            _storeRepository = storeRepository;
            _hashId = hashId;
        }

        public async Task<Store> GetById(string hashId)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _storeRepository.GetById(id[0]);
            return user;
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            var stores = await _storeRepository.GetAll();
            foreach (var store in stores)
            {
                store.Guid = _hashId.Encode(store.Id);
            }

            return stores;
        }
    }
}
