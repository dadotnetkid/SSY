using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class UpdateColorOptionFabricRollDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ColorOptionFabricId { get; set; }
    public Guid RollId { get; set; }
}