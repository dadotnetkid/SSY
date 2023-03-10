/*using System;
using SSY.Inventory.Creases;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Creases
{
    public class CreaseDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Crease, int> _creaseRepository;

        public CreaseDataSeederContributor(IRepository<Crease, int> creaseRepository)
        {
            _creaseRepository = creaseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _creaseRepository.GetCountAsync() <= 0)
            {
                await _creaseRepository.InsertAsync(new Crease(1001, "Yes", "Yes", 2));
                await _creaseRepository.InsertAsync(new Crease(1002, "No", "No", 1));
            }
        }
    }
}

*/