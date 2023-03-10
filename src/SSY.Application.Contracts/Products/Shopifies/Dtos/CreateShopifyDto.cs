using System;
using System.Collections.Generic;

namespace SSY.Products.Shopifies.Dtos;

public class CreateShopifyDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public string Name { get; set; }
    public double Price { get; set; }
    public string FabricComposition { get; set; }
    public string CareInstruction { get; set; }
}