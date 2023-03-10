/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.AdditionRequests.Types
{
    public class TypeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Type, int> _typeRepository;

        public TypeDataSeederContributor(IRepository<Type, int> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _typeRepository.GetCountAsync() <= 0)
            {
                await _typeRepository.InsertAsync(new Type(1, true, 1001, "Sublimation", "Sublimation", 1001));
                await _typeRepository.InsertAsync(new Type(1, true, 1002, "Purchase", "Purchase", 1002));
            }
        }

    }
}*/