using System;

namespace SSY.Products.Pricings.Dtos;

public class CreatePricingDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public double RetailPrice { get; set; }
    public double ShippingPremium { get; set; }
    public double NetPrice { get; set; }
}