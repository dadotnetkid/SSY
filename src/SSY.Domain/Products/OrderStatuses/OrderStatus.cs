using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.OrderStatuses;

public class OrderStatus : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual string Label { get; protected set; }
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }

    protected OrderStatus()
    {
    }

    internal OrderStatus(int id, bool isActive, string label, string value, int orderNumber)
    {
        Id = id;
        IsActive = isActive;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
    }
}