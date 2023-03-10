using System;

namespace SSY.Products.Dtos;

public class UpdateProductMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public bool? InternalIsApproved { get; set; }
    public DateTime? InternalIsApprovedDateTime { get; set; }
    public string InternalApprovedBy { get; set; }

    public bool? InfluencerIsApproved { get; set; }
    public DateTime? InfluencerIsApprovedDateTime { get; set; }
    public string InfluencerApprovedBy { get; set; }

    public Guid MediaFileId { get; set; }
}