using System;
using SSY.Products.MediaFiles.Dtos;

namespace SSY.Products.Dtos;

public class ProductMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public bool? InternalIsApproved { get; set; }
    public DateTime? InternalIsApprovedDateTime { get; set; }
    public string InternalApprovedBy { get; set; }

    public bool? InfluencerIsApproved { get; set; }
    public DateTime? InfluencerIsApprovedDateTime { get; set; }
    public string InfluencerApprovedBy { get; set; }

    public MediaFileDto MediaFile { get; set; }
}