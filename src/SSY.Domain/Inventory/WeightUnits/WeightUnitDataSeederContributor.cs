/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.WeightUnits
{
    public class WeightUnitDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<WeightUnit, int> _weightUnitRepository;

        public WeightUnitDataSeederContributor(IRepository<WeightUnit, int> weightUnitRepository)
        {
            _weightUnitRepository = weightUnitRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _weightUnitRepository.GetCountAsync() <= 0)
            {
                await _weightUnitRepository.InsertAsync(new WeightUnit(1001, "GM", "GM", 1002));
                await _weightUnitRepository.InsertAsync(new WeightUnit(1002, "GM/YD", "GM/YD", 1003));
                await _weightUnitRepository.InsertAsync(new WeightUnit(1003, "G/M2", "G/M2", 1001));
                await _weightUnitRepository.InsertAsync(new WeightUnit(1004, "Grams", "Grams", 1004));
            }
        }
    }
}

*/