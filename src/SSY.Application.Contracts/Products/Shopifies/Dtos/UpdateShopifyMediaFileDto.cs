using System;

namespace SSY.Products.Shopifies.Dtos;

public class UpdateShopifyMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid MediaFileId { get; set; }
    public int OrderNumber { get; set; }
}