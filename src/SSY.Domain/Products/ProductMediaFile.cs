using System;
using SSY.Products.CustomFilters;
using SSY.Products.MediaFiles;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products;

public class ProductMediaFile : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual bool? InternalIsApproved { get; protected set; }
    public virtual DateTime? InternalIsApprovedDateTime { get; protected set; }
    public virtual string InternalApprovedBy { get; protected set; }

    public virtual bool? InfluencerIsApproved { get; protected set; }
    public virtual DateTime? InfluencerIsApprovedDateTime { get; protected set; }
    public virtual string InfluencerApprovedBy { get; protected set; }

    public virtual Guid ProductId { get; protected set; }

    public virtual Guid MediaFileId { get; protected set; }
    public virtual MediaFiles.MediaFile MediaFile { get; protected set; }

    protected ProductMediaFile()
    {
    }

    internal ProductMediaFile(Guid productId, Guid mediaFileId)
    {
        ProductId = productId;
        MediaFileId = mediaFileId;
        IsActive = true;
    }

    internal ProductMediaFile(Guid productId, Guid mediaFileId, bool isActive)
    {
        ProductId = productId;
        MediaFileId = mediaFileId;
        IsActive = isActive;
    }

    public override object[] GetKeys()
    {
        return new object[] { ProductId, MediaFileId };
    }

    public virtual void SetProductId(Guid shopifyId)
    {
        ProductId = shopifyId;
    }

    public virtual void SetInternalApproval(bool isApproved, string approvedBy)
    {
        InternalIsApproved = isApproved;
        InternalIsApprovedDateTime = DateTime.UtcNow;
        InternalApprovedBy = approvedBy;
    }

    public virtual void SetInfluencerApproval(bool isApproved, string approvedBy)
    {
        InfluencerIsApproved = isApproved;
        InfluencerIsApprovedDateTime = DateTime.UtcNow;
        InfluencerApprovedBy = approvedBy;
    }
}