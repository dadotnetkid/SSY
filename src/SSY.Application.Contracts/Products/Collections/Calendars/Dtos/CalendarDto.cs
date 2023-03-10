using SSY.Products.Collections.DesignStatuses.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Calendars.Dtos
{
    public class CalendarDto : FullAuditedEntityDto<Guid>
    {
        public virtual Guid? TenantId { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual Guid Id { get; set; }
        public virtual Guid? CollectionId { get; set; }
        public virtual decimal SalesForecastQuantity { get; set; }

        public virtual decimal ActualSalesQuantity { get; set; }
        public virtual DateTime ActualDate { get; set; }
    }

    public class CalendarDesignStatusDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
    public class CalendarProductStatusDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public DesignStatusDto DesignStatus { get; set; }
    }
}
