using Volo.Abp.Application.Dtos;
using System;

namespace SSY.Products.Collections.MarketingTypes.Dtos;

public class MarketingTypeDto : EntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
}