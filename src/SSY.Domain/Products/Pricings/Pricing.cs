using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Pricings;

public class Pricing : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid? ProductId { get; protected set; }
    public virtual Product Product { get; protected set; }

    public virtual double RetailPrice { get; protected set; }
    public virtual double ShippingPremium { get; protected set; }
    public virtual double NetPrice { get; protected set; }

    protected Pricing()
    {
    }
}