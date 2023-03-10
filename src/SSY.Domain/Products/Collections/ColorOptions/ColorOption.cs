using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.ColorOptions;

public class ColorOption : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid CollectionId { get; protected set; }

    public virtual string Title { get; protected set; }
    public virtual int ColorId { get; protected set; }
    public virtual string ColorShortCode { get; protected set; }
    public virtual string ColorValue { get; protected set; }
    public virtual int TypeId { get; protected set; }
  
    public virtual bool? IsApproved { get; protected set; }
    public virtual bool? IsRejected { get; protected set; }
    public virtual DateTime? ApprovedOn { get; protected set; }
    public virtual string ApprovedBy { get; protected set; }
    public virtual ICollection<ColorOptionProductType> ProductTypes { get; protected set; }

    public virtual ICollection<ColorOptionFabric> Fabrics { get; protected set; }

    protected ColorOption()
    {
        ProductTypes = new Collection<ColorOptionProductType>();
        Fabrics = new Collection<ColorOptionFabric>();
    }

    public virtual void AddProductType(ColorOptionProductType productType)
    {
        ProductTypes.Add(productType);
    }

    public virtual void AddProductTypes(List<ColorOptionProductType> productTypes)
    {
        ClearProductTypes();
        productTypes.ForEach(ProductTypes.Add);
    }

    public virtual void ClearProductTypes()
    {
        ProductTypes.Clear();
    }

    public virtual void AddFabric(ColorOptionFabric fabric)
    {
        Fabrics.Add(fabric);
    }

    public virtual void AddRolls(List<ColorOptionFabric> fabrics)
    {
        ClearFabrics();
        fabrics.ForEach(Fabrics.Add);
    }

    public virtual void ClearFabrics()
    {
        Fabrics.Clear();
    }

    public virtual void Approve(string approvedBy)
    {
        IsActive = true;
        IsApproved = true;
        IsRejected = false;
        ApprovedOn = DateTime.Now;
        ApprovedBy = approvedBy;
    }

    public virtual void Reject(string approvedBy)
    {
        IsActive = false;
        IsRejected = true;
        IsApproved = false;
        ApprovedOn = DateTime.Now;
        ApprovedBy = approvedBy;
    }

    public virtual void ResetApproval()
    {
        IsActive = true;
        IsRejected = null;
        IsApproved = null;
        ApprovedOn = null;
        ApprovedBy = null;
    }

  
}