using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Seasons;

public class SeasonDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Season, int> _seasonRepository;

    public SeasonDataSeederContributor(IRepository<Season, int> seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _seasonRepository.GetCountAsync() <= 0)
        {
            await _seasonRepository.InsertAsync(new Season(1001, "SS", "Spring/Summer", 1001), autoSave: true);
            await _seasonRepository.InsertAsync(new Season(1002, "AW", "Autumn/Winter", 1002), autoSave: true);
            await _seasonRepository.InsertAsync(new Season(1003, "BO", "Best Of", 1003), autoSave: true);
        }
    }
}