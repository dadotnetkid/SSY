using System;
using System.ComponentModel.DataAnnotations.Schema;

using SSY.Enums;

namespace SSY.Companies
{
    [Table("AppCompanyExcessReminderKeys")]
    public class CompanyExcessReminderKey : Entity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        public Month ExcessReminder { get; set; }

        public CompanyExcessReminderKey()
		{
		}

        public CompanyExcessReminderKey(int tenantId, bool isActive, int companyId, Month excessReminder)
        {
            TenantId = tenantId;
            IsActive = isActive;
            CompanyId = companyId;
            ExcessReminder = excessReminder;
        }
    }
}

