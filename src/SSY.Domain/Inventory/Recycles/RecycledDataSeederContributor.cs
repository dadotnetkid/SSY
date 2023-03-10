/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Recycleds
{
    public class RecycledDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Recycled, int> _recycledRepository;

        public RecycledDataSeederContributor(IRepository<Recycled, int> recycledRepository)
        {
            _recycledRepository = recycledRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _recycledRepository.GetCountAsync() <= 0)
            {
                await _recycledRepository.InsertAsync(new Recycled(1001, "Yes", "Yes", 2));
                await _recycledRepository.InsertAsync(new Recycled(1002, "No", "No", 1));
            }
        }
    }
}

*/