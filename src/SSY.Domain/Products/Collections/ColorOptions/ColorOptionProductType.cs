using System;
using SSY.Products.CustomFilters;
using SSY.Products.Types;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.ColorOptions;

public class ColorOptionProductType : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid ColorOptionId { get; protected set; }
    public virtual Types.Type ProductType { get; protected set; }
    public virtual int ProductTypeId { get; protected set; }

    protected ColorOptionProductType()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { ColorOptionId, ProductTypeId };
    }
}