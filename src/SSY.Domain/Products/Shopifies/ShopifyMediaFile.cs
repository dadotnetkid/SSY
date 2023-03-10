using System;
using SSY.Products.CustomFilters;
using SSY.Products.MediaFiles;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Shopifies;

public class ShopifyMediaFile : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid ShopifyId { get; protected set; }

    public virtual Guid MediaFileId { get; protected set; }
    public virtual MediaFiles.MediaFile MediaFile { get; protected set; }

    // TODO: Use to arrange images in shopify 
    public int OrderNumber { get; protected set; }

    protected ShopifyMediaFile()
    {
    }

    internal ShopifyMediaFile(Guid shopifyId, Guid mediaFileId)
    {
        ShopifyId = shopifyId;
        MediaFileId = mediaFileId;
    }

    public override object[] GetKeys()
    {
        return new object[] { ShopifyId, MediaFileId };
    }

    public void SetOrderNumber(int orderNumber)
    {
        OrderNumber = orderNumber;
    }

    public virtual void SetShopifyId(Guid shopifyId)
    {
        ShopifyId = shopifyId;
    }
}