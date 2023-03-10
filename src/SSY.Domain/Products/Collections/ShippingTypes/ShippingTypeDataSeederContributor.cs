using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.ShippingTypes;

public class ShippingTypeDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ShippingType, int> _shippingTypeRepository;

    public ShippingTypeDataSeederContributor(IRepository<ShippingType, int> shippingTypeRepository)
    {
        _shippingTypeRepository = shippingTypeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _shippingTypeRepository.GetCountAsync() <= 0)
        {
            await _shippingTypeRepository.InsertAsync(new ShippingType(1001, "Free Shipping (DHL)", "Free Shipping (DHL)", 1001), autoSave: true);
            await _shippingTypeRepository.InsertAsync(new ShippingType(1002, "10 USD Shipping", "10 USD Shipping", 1002), autoSave: true);
            await _shippingTypeRepository.InsertAsync(new ShippingType(1003, "15 USD Shipping", "15 USD Shipping", 1003), autoSave: true);
            await _shippingTypeRepository.InsertAsync(new ShippingType(1004, "20 USD Shipping", "20 USD Shipping", 1004), autoSave: true);
            await _shippingTypeRepository.InsertAsync(new ShippingType(1005, "Free Shipping (FedEx)", "Free Shipping (FedEx)", 1005), autoSave: true);
        }
    }
}