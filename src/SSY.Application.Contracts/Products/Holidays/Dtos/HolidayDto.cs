using System;
using System.Collections.Generic;
using SSY.Enums;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Holidays.Dtos;

public class HolidayDto : FullAuditedEntityDto<long>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public int OrderNumber { get; set; }
    public HolidayType HolidayType { get; set; }
    public DateTime HolidayDate { get; set; }
}