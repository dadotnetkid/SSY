using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.PricePoints;

public class PricePointDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<PricePoint, int> _pricePointRepository;

    public PricePointDataSeederContributor(IRepository<PricePoint, int> pricePointRepository)
    {
        _pricePointRepository = pricePointRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _pricePointRepository.GetCountAsync() <= 0)
        {
            await _pricePointRepository.InsertAsync(new PricePoint(1001, "High", "High", 1001), autoSave: true);
            await _pricePointRepository.InsertAsync(new PricePoint(1002, "Medium", "Medium", 1002), autoSave: true);
            await _pricePointRepository.InsertAsync(new PricePoint(1003, "Low", "Low", 1003), autoSave: true);
        }
    }
}