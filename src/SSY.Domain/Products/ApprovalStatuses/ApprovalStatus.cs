using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.ApprovalStatuses;

public class ApprovalStatus : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual string Label { get; protected set; }
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }

    protected ApprovalStatus()
    {
    }

    internal ApprovalStatus(int id, string label, string value, int orderNumber)
    {
        Id = id;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        IsActive = true;
    }
    internal ApprovalStatus(int id, string label, string value, int orderNumber, bool isActive)
    {
        Id = id;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        IsActive = isActive;
    }
}