using SSY.Products.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Products.Collections;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using SSY.Products.Collections.CalendarDetails;

namespace SSY.Products.Collections.Calendars
{
    public class Calendar : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual Guid Id { get; protected set; }
        public virtual Guid? CollectionId { get; protected set; }
        public virtual decimal SalesForecastQuantity { get; protected set; }

        public virtual decimal ActualSalesQuantity { get; protected set; }
        public virtual DateTime CollectionDevelopmentTarget { get; protected set; }

        public virtual Collection Collection { get; set; }
        public virtual ICollection<CalendarDetail> CalendarDetails { get; set; }

        public Calendar(Guid id, Guid? collectionId, decimal salesForecastQuantity, decimal actualSalesQuantity, DateTime collectionDevelopmentTarget, bool isActive)
        {
            Id = id;
            CollectionId = collectionId;
            SalesForecastQuantity = salesForecastQuantity;
            ActualSalesQuantity = actualSalesQuantity;
            CollectionDevelopmentTarget = collectionDevelopmentTarget;
            IsActive = isActive;
            CalendarDetails = new HashSet<CalendarDetail>();
        }

        public Calendar()
        {
            CalendarDetails = new HashSet<CalendarDetail>();
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
