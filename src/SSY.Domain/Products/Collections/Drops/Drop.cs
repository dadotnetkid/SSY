﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.Drops;

public class Drop : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    /// <summary>
    /// Label
    /// </summary>
    public virtual string Label { get; protected set; }

    /// <summary>
    /// Value
    /// </summary>
    public virtual string Value { get; protected set; }

    /// <summary>
    /// Order Number is use for sorting
    /// </summary>
    public virtual int OrderNumber { get; protected set; }

    protected Drop()
    {
    }

    public Drop(int id, string label, string value, int orderNumber)
    {
        Id = id;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        IsActive = true;
    }
}
