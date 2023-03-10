using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Pricings.Dtos;

public class UpdatePricingDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public int RetailPrice { get; set; }
    public int ShippingPremium { get; set; }
    public int NetPrice { get; set; }
}