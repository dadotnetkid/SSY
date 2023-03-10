/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Shadings
{
    public class ShadingDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Shading, int> _shadingRepository;

        public ShadingDataSeederContributor(IRepository<Shading, int> shadingRepository)
        {
            _shadingRepository = shadingRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _shadingRepository.GetCountAsync() <= 0)
            {
                await _shadingRepository.InsertAsync(new Shading(1001, "To Follow", "To Follow", 1005));
                await _shadingRepository.InsertAsync(new Shading(1002, "A (yellow)", "A (yellow)", 1001));
                await _shadingRepository.InsertAsync(new Shading(1003, "B (blue)", "B (blue)", 1002));
                await _shadingRepository.InsertAsync(new Shading(1004, "C (red)", "C (red)", 1003));
                await _shadingRepository.InsertAsync(new Shading(1005, "D (brownish)", "D (brownish)", 1004));
            }
        }
    }
}

*/