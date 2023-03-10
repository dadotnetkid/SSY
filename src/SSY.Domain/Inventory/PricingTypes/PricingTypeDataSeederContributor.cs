/*using System;
using SSY.Inventory.PricingTypes;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.PricingTypes
{
    public class PricingTypeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<PricingType, int> _pricingTypeRepository;

        public PricingTypeDataSeederContributor(IRepository<PricingType, int> pricingTypeRepository)
        {
            _pricingTypeRepository = pricingTypeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _pricingTypeRepository.GetCountAsync() <= 0)
            {
                await _pricingTypeRepository.InsertAsync(new PricingType(1001, "External", "External", 1001));
                await _pricingTypeRepository.InsertAsync(new PricingType(1002, "Internal", "Internal", 1002));
            }
        }
    }
}

*/