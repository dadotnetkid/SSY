using System;
using SSY.Products.Collections.DesignStatuses;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Statuses;

public class Status : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual DesignStatus DesignStatus { get; protected set; }
    public virtual int DesignStatusId { get; protected set; }
    public virtual string Label { get; protected set; }
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }

    protected Status()
    {
    }

    internal Status(int id, int designStatusId, bool isActive, string label, string value, int orderNumber)
    {
        Id = id;
        DesignStatusId = designStatusId;
        IsActive = isActive;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
    }
}