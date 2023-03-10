using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSY.Inventory.Materials
{
    public class MaterialManager : DomainService, IMaterialManager
    {
        private readonly IRepository<Material, Guid> _materialRepository;
        private readonly IRepository<Roll, Guid> _rollAndLocationRepository;

        public MaterialManager(
            IRepository<Roll, Guid> rollAndLocationRepository,
            IRepository<Material, Guid> materialRepository)
        {
            _rollAndLocationRepository = rollAndLocationRepository;
            _materialRepository = materialRepository;
        }

        public async Task CalculateActualCountAsync(Material material)
        {
            List<Roll> roll = await _rollAndLocationRepository.GetListAsync();

            material.TotalCount = roll.Sum(x => x.TotalCount.Value);
        }

        public async Task CalculateAvailableCountAsync(Material material)
        {
            material.ReservedCount ??= 0;

            material.AvailableCount = material.TotalCount - material.ReservedCount;
        }

        
    }
}

