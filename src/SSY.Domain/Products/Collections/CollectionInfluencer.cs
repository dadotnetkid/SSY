using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections;

public class CollectionInfluencer : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid CollectionId { get; protected set; }
    public virtual Guid InfluencerId { get; protected set; }
    public virtual string InfluencerFullName { get; protected set; }
    public virtual string InfluencerName { get; protected set; }
    public virtual string InfluencerSurname { get; protected set; }

    protected CollectionInfluencer()
    {
    }

    public override object[] GetKeys()
    {
        return new object[] { CollectionId, InfluencerId };
    }
}