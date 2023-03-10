using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class CreateColorOptionProductTypeDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int ProductTypeId { get; set; }
}