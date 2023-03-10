using System;
using SSY.Products.CustomFilters;

using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.RejectionNotes;

public class RejectionNoteMediaFile : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid? RejectionNoteId { get; protected set; }

    public virtual Guid? MediaFileId { get; protected set; }
    public virtual MediaFiles.MediaFile MediaFile { get; protected set; }

    protected RejectionNoteMediaFile()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { RejectionNoteId, MediaFileId };
    }

    public virtual void SetRejectionNoteId(Guid rejectionNoteId)
    {
        RejectionNoteId = rejectionNoteId;
    }
}