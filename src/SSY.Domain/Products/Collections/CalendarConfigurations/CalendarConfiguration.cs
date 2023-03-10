using System;
using SSY.Products.CustomFilters;
using SSY.Products.Statuses;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.CalendarConfigurations;

public class CalendarConfiguration : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Products.Statuses.Status ProductStatus { get; protected set; }
    public virtual int ProductStatusId { get; protected set; }
    public virtual string Remarks { get; protected set; }
    public virtual int Value { get; protected set; }
    public virtual int Order { get; protected set; }

    protected CalendarConfiguration()
    {
    }

    internal CalendarConfiguration(int id, int productStatusId, int value, int order, string remarks)
    {
        Id = id;
        ProductStatusId = productStatusId;
        Remarks = remarks;
        Value = value;
        Order = order;
        IsActive = true;
    }
}