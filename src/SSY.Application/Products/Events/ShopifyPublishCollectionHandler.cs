using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopifySharp;
using SSY.Products.Shopifies;
using SSY.Products.Shopifies.Dtos;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

namespace SSY.Products.Events;

public class ShopifyPublishCollectionHandler : ILocalEventHandler<ShopifyOnPublishCollectionEvent>, ITransientDependency
{
    private readonly IRepository<Collections.Collection, Guid> _repository;

    public ShopifyPublishCollectionHandler(IRepository<Collections.Collection, Guid> repository)
    {
        _repository = repository;
    }
    public async Task HandleEventAsync(ShopifyOnPublishCollectionEvent eventData)
    {
        try
        {
            var res = await _repository.WithDetails().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(c => c.Id == eventData.CollectionId);
            res.SetAvailability(true);
            res.SetShopifyId(eventData.ShopifyId);
            await _repository.UpdateAsync(res, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}