using System;
using SSY.Products.CustomFilters;
using SSY.Products.Sizes;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections;

public class CollectionSize : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid CollectionId { get; protected set; }

    public virtual int SizeId { get; protected set; }
    public virtual Size Size { get; protected set; }

    protected CollectionSize()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { CollectionId, SizeId };
    }
}