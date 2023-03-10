/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Compressions
{
    public class CompressionDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Compression, int> _compressionRepository;

        public CompressionDataSeederContributor(IRepository<Compression, int> compressionRepository)
        {
            _compressionRepository = compressionRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _compressionRepository.GetCountAsync() <= 0)
            {
                await _compressionRepository.InsertAsync(new Compression(1001, "-1", "-1", 1));
                await _compressionRepository.InsertAsync(new Compression(1002, "0", "0", 2));
                await _compressionRepository.InsertAsync(new Compression(1003, "1", "1", 3));
            }
        }
    }
}

*/