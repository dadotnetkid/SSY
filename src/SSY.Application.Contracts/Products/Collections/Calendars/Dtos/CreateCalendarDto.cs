using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Calendars.Dtos;

public class CreateCalendarDto : FullAuditedEntityDto<Guid>
{
    public virtual Guid? TenantId { get; set; }
    public virtual bool IsActive { get; set; }

    public virtual Guid Id { get; set; }
    public virtual Guid? CollectionId { get; set; }
    public virtual decimal SalesForecastQuantity { get; set; }
    public virtual decimal ActualSalesQuantity { get; set; }
    public virtual DateTime CollectionDevelopmentTarget{ get; set; }
}