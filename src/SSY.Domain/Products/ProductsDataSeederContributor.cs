using SSY.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products
{
    public class ProductsDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductsDataSeederContributor(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //if (await _productRepository.GetCountAsync() <= 0)
            //{
            //    await _productRepository.InsertAsync(
            //        new Product
            //        {
            //            CollectionId = Guid.NewGuid(),
            //            MaterialTypeId = 1,
            //            TypeId = 1,
            //            ApprovalStatusId = 1,
            //            Sku = "20220101",
            //            Name = "Product Name",
            //            DesignStatusId = 1,
            //        },
            //        autoSave: true
            //    );

            //    await _productRepository.InsertAsync(
            //        new Product
            //        {
            //            CollectionId = Guid.NewGuid(),
            //            MaterialTypeId = 2,
            //            TypeId = 2,
            //            ApprovalStatusId = 2,
            //            Sku = "20220202",
            //            Name = "Product Name 2",
            //            DesignStatusId = 2,
            //        },
            //        autoSave: true
            //    );
            //}
        }
    }
}