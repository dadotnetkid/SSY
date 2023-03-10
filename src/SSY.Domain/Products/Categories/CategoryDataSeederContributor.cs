using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Categories;

public class CategoryDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, int> _categoryRepository;

    public CategoryDataSeederContributor(IRepository<Category, int> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            await _categoryRepository.InsertAsync(new Category(1001, "Bra", "Bra", 1, 25), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1002, "Dress", "Dress", 2, 5), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1003, "Hoodie", "Hoodie", 3, 15), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1004, "Pants", "Pants", 4, 15), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1005, "Shorts", "Shorts", 5, 15), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1006, "Skirt", "Skirt", 6, 3), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1007, "Tank", "Tank", 7, 10), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1008, "Tshirt", "Tshirt", 8, 2), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1009, "Lounge", "Lounge", 9, 10), autoSave: true);
            await _categoryRepository.InsertAsync(new Category(1010, "Jacket", "Jacket", 10, 10), autoSave: true);
        }
    }
}