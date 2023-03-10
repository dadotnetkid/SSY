/*using System;
using SSY.Inventory.HandFeels;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.HandFeels
{
    public class HandFeelDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<HandFeel, int> _handFeelRepository;

        public HandFeelDataSeederContributor(IRepository<HandFeel, int> handFeelRepository)
        {
            _handFeelRepository = handFeelRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _handFeelRepository.GetCountAsync() <= 0)
            {
                await _handFeelRepository.InsertAsync(new HandFeel(1001, "Soft", "Soft", 1005));
                await _handFeelRepository.InsertAsync(new HandFeel(1002, "Peachy", "Peachy", 1002));
                await _handFeelRepository.InsertAsync(new HandFeel(1003, "Slippery", "Slippery", 1004));
                await _handFeelRepository.InsertAsync(new HandFeel(1004, "Bumpy", "Bumpy", 1001));
                await _handFeelRepository.InsertAsync(new HandFeel(1005, "Rough", "Rough", 1003));
            }
        }
    }
}

*/