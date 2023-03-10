/*using System;
using System.Threading.Tasks;
using SSY.Inventory.Creases;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Currencies
{
    public class CurrencyDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Currency, int> _currencyRepository;

        public CurrencyDataSeederContributor(IRepository<Currency, int> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _currencyRepository.GetCountAsync() <= 0)
            {
                await _currencyRepository.InsertAsync(new Currency(1001, "USD", "USD", 1003));
                await _currencyRepository.InsertAsync(new Currency(1002, "PHP", "PHP", 1002));
                await _currencyRepository.InsertAsync(new Currency(1003, "HKD", "HKD", 1001));
            }
        }
    }
}

*/