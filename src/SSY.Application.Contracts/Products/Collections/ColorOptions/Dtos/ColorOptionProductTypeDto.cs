using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class ColorOptionProductTypeDto : EntityDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ColorOptionId { get; set; }
    public int ProductTypeId { get; set; }
}