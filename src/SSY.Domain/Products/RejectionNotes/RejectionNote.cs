using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSY.Products.CustomFilters;
using SSY.Products.MediaFiles;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.RejectionNotes;

public class RejectionNote : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    /// <summary>
    /// ProductId
    /// </summary>
    public virtual Guid? ProductId { get; protected set; }

    /// <summary>
    /// MediaFileCategoryId
    /// </summary>
    public virtual int MediaFileCategoryId { get; protected set; }

    public virtual bool IsInternal { get; protected set; }

    /// <summary>
    /// Notes - example: Reason for rejection
    /// </summary>
    public virtual string Notes { get; protected set; }

    /// <summary>
    /// UserName
    /// </summary>
    //public virtual Guid? UserId { get; protected set; }
    public virtual string UserName { get; protected set; }

    public virtual ICollection<RejectionNoteMediaFile> MediaFiles { get; protected set; }

    protected RejectionNote()
    {
        MediaFiles = new Collection<RejectionNoteMediaFile>();
    }

    public virtual void SetProductId(Guid productId)
    {
        ProductId = productId;
    }

    public virtual void AddMediaFiles(List<RejectionNoteMediaFile> mediaFiles)
    {
        mediaFiles.ForEach(mediaFile =>
        {
            MediaFiles.Add(mediaFile);
        });
    }

    public virtual void ClearMediaFiles()
    {
        MediaFiles.Clear();
    }
}