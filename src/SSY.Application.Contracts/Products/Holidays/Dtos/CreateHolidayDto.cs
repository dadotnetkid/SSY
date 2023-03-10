using System;
using SSY.Enums;
using Volo.Abp.Application.Dtos;

public class CreateHolidayDto : EntityDto<long>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public string Name { get; set; }
    public int OrderNumber { get; set; }
    public HolidayType HolidayType { get; set; }
    public DateTime HolidayDate { get; set; }
}