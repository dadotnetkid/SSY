using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Pricings.Dtos;

public class PricingDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public int RetailPrice { get; set; }
    public int ShippingPremium { get; set; }
    public int NetPrice { get; set; }
}