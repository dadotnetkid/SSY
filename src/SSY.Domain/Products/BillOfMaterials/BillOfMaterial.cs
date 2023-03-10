using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.BillOfMaterials;

public class BillOfMaterial : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Product Product { get; protected set; }
    public virtual Guid? ProductId { get; protected set; }
    public virtual int PartNumber { get; protected set; }
    public virtual string PartName { get; protected set; }
    public virtual string ColorCode { get; protected set; }
    public virtual string ItemCode { get; protected set; }
    public virtual Guid? MaterialId { get; protected set; }
    public virtual double Consumption { get; protected set; }
    public virtual string UnitOfMeasurement { get; protected set; }
    public virtual string CuttableWidth { get; protected set; }
    public virtual string ContentDescription { get; protected set; }
    public virtual double Price { get; protected set; }
    public virtual string Supplier { get; protected set; }

    public virtual string Notes { get; protected set; }

    protected BillOfMaterial()
    {
    }

    public virtual void SetProductId(Guid productId)
    {
        ProductId = productId;
    }

    public virtual void SetConsumption(double consumption)
    {
        Consumption = consumption;
    }

    public virtual void SetNotes(string notes)
    {
        Notes = notes;
    }
}