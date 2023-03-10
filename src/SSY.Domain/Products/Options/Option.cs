using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSY.Products.CustomFilters;
using SSY.Products.Types;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Options;

public class Option : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int? ParentId { get; protected set; }
    public virtual ICollection<Option> Options { get; protected set; }

    public virtual string Label { get; protected set; }
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }
    public virtual bool HasPanel { get; protected set; }

    protected Option()
    {
        Options = new Collection<Option>();
    }

    internal Option(int id, bool isActive, string label, string value, int orderNumber, bool hasPanel, int? parentId = null)
    {
        Id = id;
        IsActive = isActive;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        ParentId = parentId;
        HasPanel = hasPanel;
    }

    public void AddOption(Option option)
    {
        Options.Add(option);
    }
}