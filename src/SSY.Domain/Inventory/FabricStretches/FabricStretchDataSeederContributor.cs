/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.FabricStretches
{
    public class FabricStretchDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<FabricStretch, int> _fabricStretchRepository;

        public FabricStretchDataSeederContributor(IRepository<FabricStretch, int> fabricStretchRepository)
        {
            _fabricStretchRepository = fabricStretchRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _fabricStretchRepository.GetCountAsync() <= 0)
            {
                await _fabricStretchRepository.InsertAsync(new FabricStretch(1001, "No Stretch", "No Stretch", 1003));
                await _fabricStretchRepository.InsertAsync(new FabricStretch(1002, "2 Ways Stretch", "2 Ways Stretch", 1001));
                await _fabricStretchRepository.InsertAsync(new FabricStretch(1003, "4 Ways Stretch", "4 Ways Stretch", 1002));
            }
        }
    }
}

*/