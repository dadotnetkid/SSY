/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.UpchargeTypes
{
    public class UpchargeTypeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<UpchargeType, int> _upchargeTypeRepository;

        public UpchargeTypeDataSeederContributor(IRepository<UpchargeType, int> upchargeTypeRepository)
        {
            _upchargeTypeRepository = upchargeTypeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _upchargeTypeRepository.GetCountAsync() <= 0)
            {
                await _upchargeTypeRepository.InsertAsync(new UpchargeType(1001, "Percentage", "Percentage", 1001));
                await _upchargeTypeRepository.InsertAsync(new UpchargeType(1002, "Specific", "Specific", 1002));
            }
        }
    }
}

*/