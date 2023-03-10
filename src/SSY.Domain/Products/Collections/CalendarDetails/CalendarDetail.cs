

using System;
using JetBrains.Annotations;
using SSY.Products.Collections.Calendars;
using SSY.Products.Collections.DesignStatuses;
using SSY.Products.CustomFilters;
using SSY.Products.Statuses;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.CalendarDetails
{
    public class CalendarDetail : FullAuditedAggregateRoot<Guid>, IIsActive, IMultiTenant
    {
        public virtual bool IsActive { get; protected set; }
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid CalendarId { get; protected set; }
        public virtual int ProductStatusId { get; protected set; }

        public virtual Products.Statuses.Status ProductStatus { get; set; }
        public virtual Calendar Calendar { get; set; }
    }
}
