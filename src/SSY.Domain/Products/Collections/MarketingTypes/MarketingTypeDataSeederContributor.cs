using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSY.Products.Collections.PricePoints;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.MarketingTypes;

public class MarketingTypeDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<MarketingType, int> _marketingTypeRepository;

    public MarketingTypeDataSeederContributor(IRepository<MarketingType, int> marketingTypeRepository)
    {
        _marketingTypeRepository = marketingTypeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _marketingTypeRepository.GetCountAsync() <= 0)
        {
            await _marketingTypeRepository.InsertAsync(new MarketingType(1001, "TBD", "TBD", 1001), autoSave: true);
            await _marketingTypeRepository.InsertAsync(new MarketingType(1002, "Buy 3, Get 1", "Buy 3, Get 1", 1002), autoSave: true);
            await _marketingTypeRepository.InsertAsync(new MarketingType(1003, "Buy 2, Get 1", "Buy 2, Get 1", 1003), autoSave: true);
            await _marketingTypeRepository.InsertAsync(new MarketingType(1004, "Buy 1, Get 1", "Buy 1, Get 1", 1004), autoSave: true);
            await _marketingTypeRepository.InsertAsync(new MarketingType(1005, "Buy 1, Get 1 50% Off", "Buy 1, Get 1 50% Off", 1005), autoSave: true);
        }
    }
}