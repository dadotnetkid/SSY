using System;
using SSY.Products.Collections.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.AssignedTos.Dtos;

public class AssignedToDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid CollectionId { get; set; }
    public CollectionDto Collection { get; set; }

    public Guid? DesignerId { get; set; }
    public Guid? ThreeDDesignerId { get; set; }
    public Guid? SSYMerchandiserId { get; set; }
    public Guid? OEMMerchandiserId { get; set; }
    public Guid? OEMPatternMakerId { get; set; }
}