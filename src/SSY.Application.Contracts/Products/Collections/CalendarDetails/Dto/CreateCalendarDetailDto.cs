using SSY.Products.Collections.Calendars.Dtos;
using SSY.Products.Collections.DesignStatuses.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.CalendarDetails.Dto
{
    public class CreateCalendarDetailDto
    {
        public bool IsActive { get; set; }
        public Guid? TenantId { get; set; }
        public Guid CalendarId { get; set; }
        public int ProductStatusId { get; set; }
    }
}
