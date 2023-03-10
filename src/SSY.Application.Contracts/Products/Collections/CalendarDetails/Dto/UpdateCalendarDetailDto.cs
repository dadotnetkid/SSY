using System;

namespace SSY.Products.Collections.CalendarDetails.Dto;

public class UpdateCalendarDetailDto
{
    public bool IsActive { get; }
    public Guid? TenantId { get; }
    public Guid CalendarId { get; set; }
    public int DesignStatusId { get; set; }
}