using System;
using SSY.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SSY.Products.Shopifies;

public class EfCoreShopifyMediaFileRepository
    : EfCoreRepository<SSYDbContext, ShopifyMediaFile>,
    IShopifyMediaFileRepository

{
    public EfCoreShopifyMediaFileRepository(
        IDbContextProvider<SSYDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}