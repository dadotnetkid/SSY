/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.PrintRepeats
{
    public class PrintRepeatDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<PrintRepeat, int> _printRepeatRepository;

        public PrintRepeatDataSeederContributor(IRepository<PrintRepeat, int> printRepeatRepository)
        {
            _printRepeatRepository = printRepeatRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _printRepeatRepository.GetCountAsync() <= 0)
            {
                await _printRepeatRepository.InsertAsync(new PrintRepeat(1001, "Yes", "Yes", 2));
                await _printRepeatRepository.InsertAsync(new PrintRepeat(1002, "No", "No", 1));
            }
        }
    }
}
*/