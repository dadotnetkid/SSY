using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using SSY.Products.CustomFilters;
using SSY.Products.RejectionNotes;
using SSY.Products.Shopifies;
using SSY.Products.Accountings;
using SSY.Products.Pricings;
using SSY.Products.BillOfMaterials;
using SSY.Products.Collections;
using SSY.Products.LaunchCategories;
using SSY.Products.Collections.ColorOptions;

namespace SSY.Products;

public class Product : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
{
    #region Common

    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }
    public virtual string Sku { get; protected set; }
    public virtual string Name { get; protected set; }
    public virtual Types.Type Type { get; protected set; }
    public virtual int TypeId { get; protected set; }
    public virtual Statuses.Status Status { get; protected set; }
    public virtual int StatusId { get; protected set; }
    public virtual ICollection<ProductOption> Options { get; protected set; }
    public virtual ICollection<ProductMediaFile> ProductMediaFiles { get; protected set; }
    public virtual ICollection<RejectionNote> RejectionNotes { get; protected set; }

    #endregion

    #region Product
    public virtual Collection Collection { get; protected set; }
    public virtual Guid? CollectionId { get; protected set; }
    public virtual LaunchCategory LaunchCategory { get; protected set; }
    public virtual int? LaunchCategoryId { get; protected set; }
    public virtual int ApprovalStatusId { get; protected set; }
    public virtual Guid? ObjBlockPatternId { get; protected set; }
    public virtual Guid? BaseSizeSpecId { get; protected set; }
    public virtual Guid? WorkmanshipGuideId { get; protected set; }
    public virtual Guid? OEMId { get; protected set; }
    public virtual ICollection<Product> ChildProducts { get; protected set; }

    public virtual Accounting Accounting { get; protected set; }
    public virtual Pricing Pricing { get; protected set; }

    #endregion

    #region Child Product

    public virtual Guid? ParentId { get; protected set; }
    public virtual ColorOption ColorOption { get; protected set; }
    public virtual Guid? ColorOptionId { get; protected set; }
    public virtual int? ColorId { get; protected set; }
    public virtual string ColorValue { get; protected set; }
    public virtual string ColorShortCode { get; protected set; }
    public virtual int? DropId { get; protected set; }
    public virtual Shopify Shopify { get; protected set; }
    public virtual BillOfMaterial BillOfMaterial { get; protected set; }
    public virtual string ProductOptionNotes { get; protected set; }

    #endregion

    protected Product()
    {
        Options = new Collection<ProductOption>();
        ProductMediaFiles = new Collection<ProductMediaFile>();
        RejectionNotes = new Collection<RejectionNote>();
        ChildProducts = new Collection<Product>();
    }

    public virtual void AddOptions(List<ProductOption> options)
    {
        Options.Clear();
        options.ForEach(Options.Add);
    }

    public virtual void AddProductionFile(ProductMediaFile productionFile)
    {
        ProductMediaFiles.Add(productionFile);
    }

    public virtual void AddRejectionNote(RejectionNote rejectionNote)
    {
        RejectionNotes.Add(rejectionNote);
    }


    public virtual void AddChildProduct(Product product)
    {
        ChildProducts.Add(product);
    }

    public virtual void SetBillOfMaterial(BillOfMaterial bom)
    {
        BillOfMaterial = bom;
    }

    public virtual void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public virtual void Approve()
    {
        IsActive = true;
        ApprovalStatusId = 2;
    }

    public virtual void Reject()
    {
        IsActive = false;
        ApprovalStatusId = 4;
    }

    public virtual void SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
        IsActive = !isDeleted;
    }

    public virtual void SetCollectionId(Guid parentId)
    {
        ParentId = parentId;
    }

    public virtual void SetParentId(Guid parentId)
    {
        ParentId = parentId;
    }

    public virtual void SetColorOptionId(Guid colorOptionId)
    {
        ColorOptionId = colorOptionId;
    }

    public virtual void InternalApproveMediaFileCategory(int categoryId, string approvedBy)
    {
        var mediaFiles = this.ProductMediaFiles.Where(x => x.MediaFile.CategoryId == categoryId).ToList();

        mediaFiles.ForEach(x => x.SetInternalApproval(true, approvedBy));
    }

    public virtual void InfluencerApproveMediaFileCategory(int categoryId, string approvedBy)
    {
        var mediaFiles = this.ProductMediaFiles.Where(x => x.MediaFile.CategoryId == categoryId).ToList();

        mediaFiles.ForEach(x => x.SetInfluencerApproval(true, approvedBy));
    }

    public virtual void RejectMediaFileCategory(int categoryId)
    {
        this.ProductMediaFiles.RemoveAll(x => x.MediaFile.CategoryId == categoryId);
    }
}