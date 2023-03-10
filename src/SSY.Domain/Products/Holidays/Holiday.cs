using SSY.Products.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Enums;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Holidays;

public class Holiday : FullAuditedAggregateRoot<long>, IMultiTenant, IIsActive
{

    public virtual string Name { get; protected set; }
    public virtual int OrderNumber { get; protected set; }
    public virtual HolidayType HolidayType { get; protected set; }
    public virtual DateTime HolidayDate { get; protected set; }
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    protected Holiday()
    {
    }

    internal Holiday(long id, string name, int orderNumber, HolidayType holidayType, bool isActive, DateTime holidayDate)
    {
        Name = name;
        OrderNumber = orderNumber;
        HolidayType = holidayType;
        IsActive = isActive;
        Id = id;
        HolidayDate = holidayDate;
    }
}