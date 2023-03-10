using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.AssignedTos;

public class AssignedTo : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual Guid CollectionId { get; protected set; }
    public virtual Collection Collection { get; protected set; }

    public virtual Guid? DesignerId { get; protected set; }
    public virtual Guid? ThreeDDesignerId { get; protected set; }
    public virtual Guid? SSYMerchandiserId { get; protected set; }
    public virtual Guid? OEMMerchandiserId { get; protected set; }
    public virtual Guid? OEMPatternMakerId { get; protected set; }

    protected AssignedTo()
    {
    }
}