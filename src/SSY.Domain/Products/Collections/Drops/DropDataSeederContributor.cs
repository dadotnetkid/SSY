using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Drops;

public class DropDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Drop, int> _dropRepository;

    public DropDataSeederContributor(IRepository<Drop, int> dropRepository)
    {
        _dropRepository = dropRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _dropRepository.GetCountAsync() <= 0)
        {
            await _dropRepository.InsertAsync(new Drop(1001, "1st Drop", "1st Drop", 1001), autoSave: true);
            await _dropRepository.InsertAsync(new Drop(1002, "2nd Drop", "2nd Drop", 1002), autoSave: true);

        }
    }
}