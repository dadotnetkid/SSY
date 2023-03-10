using System;
using SSY.Products.CustomFilters;
using SSY.Products.Sizes;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections;

public class CollectionProductType : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid CollectionId { get; protected set; }

    public virtual int ProductTypeId { get; protected set; }
    public virtual Types.Type ProductType { get; protected set; }

    public virtual string MaterialTypeShortCode { get; protected set; }
    public virtual string MaterialTypeValue { get; protected set; }

    protected CollectionProductType()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { CollectionId, ProductTypeId };
    }
}