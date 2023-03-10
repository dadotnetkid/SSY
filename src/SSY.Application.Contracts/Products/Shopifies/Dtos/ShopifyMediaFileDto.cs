using System;
using Volo.Abp.Domain.Entities;
using SSY.Products.MediaFiles.Dtos;

namespace SSY.Products.Shopifies.Dtos;

public class ShopifyMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public MediaFileDto MediaFile { get; set; }
    public int OrderNumber { get; set; }
}