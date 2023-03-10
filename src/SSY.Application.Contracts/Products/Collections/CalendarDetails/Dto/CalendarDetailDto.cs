using System;
using SSY.Products.Collections.Calendars.Dtos;
using SSY.Products.Collections.DesignStatuses.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.CalendarDetails.Dto;

public class CalendarDetailDto:EntityDto<Guid>
{
    public bool IsActive { get; }
    public Guid? TenantId { get; }
    public Guid CalendarId { get; set; }
    public int DesignStatusId { get; set; }

    public virtual DesignStatusDto DesignStatus { get; set; }
    public virtual CalendarDto Calendar { get; set; }
}