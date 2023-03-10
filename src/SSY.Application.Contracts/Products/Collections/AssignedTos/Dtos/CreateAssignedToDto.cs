using System;

namespace SSY.Products.Collections.AssignedTos.Dtos;

public class CreateAssignedToDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid CollectionId { get; set; }

    public Guid? DesignerId { get; set; }
    public Guid? ThreeDDesignerId { get; set; }
    public Guid? SSYMerchandiserId { get; set; }
    public Guid? OEMMerchandiserId { get; set; }
    public Guid? OEMPatternMakerId { get; set; }
}