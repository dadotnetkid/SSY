/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Adjustments.Types
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
                await _typeRepository.InsertAsync(new Type(1001, 1, true, "Increment", "Increment", 1002));
                await _typeRepository.InsertAsync(new Type(1002, 1, true, "Decrement", "Decrement", 1001));
                await _typeRepository.InsertAsync(new Type(1003, 1, true, "Disposal", "Disposal", 1003));
            }
        }
    }
}

*/