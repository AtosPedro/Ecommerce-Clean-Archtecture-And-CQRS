﻿using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;
using HashidsNet;

namespace Ecommerce.Infrastructure.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IHashids _hashId;

        public MaterialService(IMaterialRepository materialRepository, IHashids hashId)
        {
            _materialRepository = materialRepository;
            _hashId = hashId;
        }

        public async Task<Material> GetById(string hashId)
        {
            int[] id = _hashId.Decode(hashId);
            var user = await _materialRepository.GetById(id[0]);
            return user;
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            var materials = await _materialRepository.GetAll();
            foreach (var units in materials)
            {
                units.Guid = _hashId.Encode(units.Id);
            }

            return materials;
        }
    }
}
