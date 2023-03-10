using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Accountings;

public class Accounting : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Product Product { get; protected set; }
    public virtual Guid? ProductId { get; protected set; }
    
    public virtual double UnitSales { get; protected set; }
    public virtual double TotalSales { get; protected set; }

    protected Accounting()
    {
    }
}