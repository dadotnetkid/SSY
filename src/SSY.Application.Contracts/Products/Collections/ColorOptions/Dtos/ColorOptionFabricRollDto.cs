using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.ColorOptions.Dtos;

public class ColorOptionFabricRollDto : EntityDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ColorOptionFabricId { get; set; }
    public Guid RollId { get; set; }
}