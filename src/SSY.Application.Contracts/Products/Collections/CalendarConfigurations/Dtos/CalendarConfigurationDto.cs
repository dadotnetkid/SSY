using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.CalendarConfigurations.Dtos;

public class CalendarConfigurationDto : EntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int ProductStatusId { get; set; }
    public string Remarks { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }
}
