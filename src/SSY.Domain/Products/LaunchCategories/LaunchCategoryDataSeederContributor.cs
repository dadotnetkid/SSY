using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.LaunchCategories;

public class LaunchCategoryDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<LaunchCategory, int> _launchCategoryRepository;

    public LaunchCategoryDataSeederContributor(IRepository<LaunchCategory, int> launchCategoryRepository)
    {
        _launchCategoryRepository = launchCategoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _launchCategoryRepository.GetCountAsync() <= 0)
        {
            await _launchCategoryRepository.InsertAsync(new LaunchCategory(1003, "Seasonal", "Seasonal", 3), autoSave: true);
            await _launchCategoryRepository.InsertAsync(new LaunchCategory(1002, "Iconic", "Iconic", 2), autoSave: true);
            await _launchCategoryRepository.InsertAsync(new LaunchCategory(1001, "Constant", "Constant", 1), autoSave: true);
        }
    }
}