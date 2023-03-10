using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Options.Dtos;

public class OptionDto : FullAuditedEntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int? ParentId { get; set; }
    public List<OptionDto> Options { get; set; }

    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
    public bool HasPanel { get; set; }

}