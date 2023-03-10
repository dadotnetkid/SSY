using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.ColorOptions;

public class ColorOptionFabricRoll : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual ColorOptionFabric ColorOptionFabric { get; protected set; }
    public virtual Guid ColorOptionFabricId { get; protected set; }
    public virtual Guid RollId { get; protected set; }

    protected ColorOptionFabricRoll()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { ColorOptionFabricId, RollId };
    }
}