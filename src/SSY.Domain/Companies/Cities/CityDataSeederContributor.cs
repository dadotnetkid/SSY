/*using System;
using System.Threading.Tasks;
using SSY.Inventory;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies.Cities
{
    public class CityDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<City, int> _cityRepository;

        public CityDataSeederContributor(IRepository<City, int> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _cityRepository.GetCountAsync() <= 0)
            {
                await _cityRepository.InsertAsync(new City(1, true, "MM", "Metro Manila", 1001), autoSave: true);
            }
        }
    }
}

*/