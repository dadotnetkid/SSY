using System;

namespace SSY.Products.Collections.ShippingTypes.Dtos;

public class CreateShippingTypeDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
}