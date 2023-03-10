using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Statuses.Dtos;

public class StatusDto : FullAuditedEntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int DesignStatusId { get; set; }
    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
}