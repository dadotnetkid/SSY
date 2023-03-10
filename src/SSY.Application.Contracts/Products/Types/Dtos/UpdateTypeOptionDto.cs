using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Types.Dtos;

public class UpdateTypeOptionDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int TypeId { get; set; }
    public int OptionId { get; set; }
}