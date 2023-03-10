using System;

namespace SSY.Products.Dtos;

public class ApproveMediaFileCatgoryDto
{
    public Guid ProductId { get; set; }
    public int MediaFileCategoryId { get; set; }
    public string ApprovedBy { get; set; }
}