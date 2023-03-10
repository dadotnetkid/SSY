using System;

namespace SSY.Products.Types.Dtos;

public class CreateTypeOptionDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int OptionId { get; set; }
}