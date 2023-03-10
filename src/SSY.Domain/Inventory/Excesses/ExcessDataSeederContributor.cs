/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Excesses
{
    public class ExcessDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Excess, int> _excessRepository;

        public ExcessDataSeederContributor(IRepository<Excess, int> excessRepository)
        {
            _excessRepository = excessRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _excessRepository.GetCountAsync() <= 0)
            {
                await _excessRepository.InsertAsync(new Excess(1001, "Yes", "Yes", 1002));
                await _excessRepository.InsertAsync(new Excess(1002, "No", "No", 1001));
            }
        }
    }
}

*/