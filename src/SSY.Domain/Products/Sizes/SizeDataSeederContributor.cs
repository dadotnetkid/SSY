using System;
using System.Threading.Tasks;
using SSY.Products.OrderStatuses;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Sizes;

public class SizeDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Size, int> _sizeRepository;

    public SizeDataSeederContributor(IRepository<Size, int> sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _sizeRepository.GetCountAsync() <= 0)
        {
            await _sizeRepository.InsertAsync(new Size(1001, true, "3XS", "3XS", 1), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1002, true, "2XS", "2XS", 2), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1003, true, "XS", "XS", 3), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1004, true, "S", "S", 4), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1005, true, "M", "M", 5), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1006, true, "L", "L", 6), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1007, true, "XL", "XL", 7), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1008, true, "2XL", "2XL", 8), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1009, true, "3XL", "3XL", 9), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1010, true, "4XL", "4XL", 10), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1011, true, "5XL", "5XL", 11), autoSave: true);
            await _sizeRepository.InsertAsync(new Size(1012, true, "6XL", "6XL", 12), autoSave: true);
        }
    }
}