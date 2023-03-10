using System;
using System.ComponentModel.DataAnnotations.Schema;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.MediaFiles.Categories;

public class Category : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual string Label { get; protected set; }
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }

    protected Category()
    {
    }

    internal Category(int id, string label, string value, int orderNumber)
    {
        Id = id;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        IsActive = true;
    }

    internal Category(int id, string label, string value, int orderNumber, bool isActive)
    {
        Id = id;
        Label = label;
        Value = value;
        OrderNumber = orderNumber;
        IsActive = isActive;
    }
}