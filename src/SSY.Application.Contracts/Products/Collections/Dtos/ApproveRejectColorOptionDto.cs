using System;

namespace SSY.Products.Collections.Dtos;

public class ApproveRejectColorOptionDto
{
    public Guid CollectionId { get; set; }
    public Guid ColorOptionId { get; set; }
    public string ApprovedBy { get; set; }
    public bool IsOnSite { get; set; }
}