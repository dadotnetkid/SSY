using Microsoft.EntityFrameworkCore;
using SSY.Products.Shopifies;
using SSY.Products.Shopifies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

namespace SSY.Products.Events
{
    public class ShopifyPublishHandler : ILocalEventHandler<ShopifyOnPublishEvent>, ITransientDependency
    {
        private readonly IRepository<Shopify, Guid> _repository;

        public ShopifyPublishHandler(IRepository<Shopify, Guid> repository)
        {
            _repository = repository;
        }
        public async Task HandleEventAsync(ShopifyOnPublishEvent eventData)
        {
            try
            {
                var res = await _repository.WithDetails().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(c => c.ProductId == eventData.ProductId);
                res.SetPublished(true);
                res.SetPublishedAt(eventData.PublishedAt.GetValueOrDefault().DateTime);
                res.SetShopifyId(eventData.ShopifyId);
                res.SetVariantId(eventData.VariantId);
                await _repository.UpdateAsync(res,true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

