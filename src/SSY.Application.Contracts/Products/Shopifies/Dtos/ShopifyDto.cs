using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Shopifies.Dtos;

public class ShopifyDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public bool Published { get; set; }
    public DateTime PublishedAt { get; set; }
    /// <summary>
    /// Shopify Id for UI
    /// </summary>
    public string Number { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string FabricComposition { get; set; }
    public string CareInstruction { get; set; }
    /// <summary>
    /// List of strings.
    /// </summary>
    public string Tags { get; set; }
    public string Description { get; set; }


    public long? ShopifyId { get; set; }
    public long? VariantId { get; set; }
    public virtual List<ShopifyMediaFileDto> MediaFiles { get; set; }
}