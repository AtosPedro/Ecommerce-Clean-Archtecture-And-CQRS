using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;
using Newtonsoft.Json.Linq;

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

        public async Task<IEnumerable<Store>> GetAll(CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetAll(cancellationToken);
            foreach (var store in stores)
            {
                store.Guid = _hashId.Encode(store.Id);
            }

            return stores;
        }

        public async Task<Store> Add(Store store, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.Add(store, cancellationToken);
            return stores;
        }

        public Task<Store> Update(Store usern)
        {
            throw new NotImplementedException();
        }

        public Task<Store> Remove(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
