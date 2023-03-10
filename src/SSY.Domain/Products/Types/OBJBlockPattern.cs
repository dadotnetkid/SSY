using System;
using SSY.Products.CustomFilters;
using SSY.Products.MediaFiles;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Types;

public class ObjBlockPattern : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int TypeId { get; set; }

    public virtual Guid MediaFileId { get; set; }
    public virtual MediaFiles.MediaFile MediaFile { get; set; }

    protected ObjBlockPattern()
    {
    }

    internal ObjBlockPattern(int typeId, Guid mediaFileId)
    {
        TypeId = typeId;
        MediaFileId = mediaFileId;
        IsActive = true;
    }
    internal ObjBlockPattern(int typeId, Guid mediaFileId, bool isActive)
    {
        TypeId = typeId;
        MediaFileId = mediaFileId;
        IsActive = isActive;
    }

    public override object[] GetKeys()
    {
        return new object[] { TypeId, MediaFileId };
    }
}