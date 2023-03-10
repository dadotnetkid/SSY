using System;
using SSY.Enums;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Holidays.Dtos;

public class UpdateHolidayDto : EntityDto<long>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public int OrderNumber { get; set; }
    public HolidayType HolidayType { get; set; }
    public DateTime HolidayDate { get; set; }
}