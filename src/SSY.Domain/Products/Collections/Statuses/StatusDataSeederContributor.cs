using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Statuses;

public class CollectionStatusDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Status, int> _statusRepository;

    public CollectionStatusDataSeederContributor(IRepository<Status, int> statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _statusRepository.GetCountAsync() <= 0)
        {
            await _statusRepository.InsertAsync(new Status(1001, "In Progress", "In Progress", 1), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1002, "On Hold", "On Hold", 2), autoSave: true);
            await _statusRepository.InsertAsync(new Status(1003, "Confirmed", "Confirmed", 3), autoSave: true);
        }
    }
}