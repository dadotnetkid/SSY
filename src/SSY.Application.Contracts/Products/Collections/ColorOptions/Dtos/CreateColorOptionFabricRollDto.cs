using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class CreateColorOptionFabricRollDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid RollId { get; set; }
}