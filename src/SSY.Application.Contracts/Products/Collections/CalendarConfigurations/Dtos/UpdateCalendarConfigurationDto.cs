using System;

namespace SSY.Products.Collections.CalendarConfigurations.Dtos;

public class UpdateCalendarConfigurationDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int Id { get; set; }
    public int ProductStatusId { get; set; }
    public string Remarks { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }
}