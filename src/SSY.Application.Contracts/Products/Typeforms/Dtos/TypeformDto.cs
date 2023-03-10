using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Typeforms.Dtos;

public class TypeformDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Type { get; set; }
    public string Response { get; set; }
}