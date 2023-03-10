/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Categories
{
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
                await _categoryRepository.InsertAsync(new Category(1, "Greige", "Greige", 1002), autoSave: true);
                await _categoryRepository.InsertAsync(new Category(2, "Fabric", "Fabric", 1001), autoSave: true);
                await _categoryRepository.InsertAsync(new Category(3, "Trims & Accessories", "TrimsAndAccessories", 1006), autoSave: true);
                await _categoryRepository.InsertAsync(new Category(4, "Packaging", "Packaging", 1005), autoSave: true);
                await _categoryRepository.InsertAsync(new Category(5, "Yarn", "Yarn", 1007), autoSave: true);
                await _categoryRepository.InsertAsync(new Category(99, "Others", "Others", 1003), autoSave: true);
            }
        }
    }
}

*/