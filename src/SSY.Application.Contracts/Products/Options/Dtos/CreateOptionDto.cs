using System;
using System.Collections.Generic;

namespace SSY.Products.Options.Dtos;

public class CreateOptionDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int? ParentId { get; set; }
    public List<CreateOptionDto> Options { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
    public bool HasPanel { get; set; }


}