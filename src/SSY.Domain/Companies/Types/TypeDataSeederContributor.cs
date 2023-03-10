/*using System;
using System.Threading.Tasks;
using SSY.Companies.Types;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies.Types
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

            }
        }
    }
}

*/