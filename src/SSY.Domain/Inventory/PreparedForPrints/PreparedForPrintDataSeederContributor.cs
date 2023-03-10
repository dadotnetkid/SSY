/*using System;
using SSY.Inventory.PreparedForPrints;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.PreparedForPrints
{
    public class PreparedForPrintDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<PreparedForPrint, int> _preparedForPrintRepository;

        public PreparedForPrintDataSeederContributor(IRepository<PreparedForPrint, int> preparedForPrintRepository)
        {
            _preparedForPrintRepository = preparedForPrintRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _preparedForPrintRepository.GetCountAsync() <= 0)
            {
                await _preparedForPrintRepository.InsertAsync(new PreparedForPrint(1001, "Yes", "Yes", 2));
                await _preparedForPrintRepository.InsertAsync(new PreparedForPrint(1002, "No", "No", 1));
            }
        }
    }
}

*/