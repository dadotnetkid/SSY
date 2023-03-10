using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Factories;

public class FactoryDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Factory, int> _factoryRepository;

    public FactoryDataSeederContributor(IRepository<Factory, int> factoryRepository)
    {
        _factoryRepository = factoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _factoryRepository.GetCountAsync() <= 0)
        {
            await _factoryRepository.InsertAsync(new Factory(1001, "Tien Hu", "Tien Hu", 1002), autoSave: true);
            await _factoryRepository.InsertAsync(new Factory(1002, "Cebu", "Cebu", 1001), autoSave: true);
        }
    }
}