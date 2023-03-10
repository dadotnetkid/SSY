using System;
using System.ComponentModel.DataAnnotations.Schema;
using SSY.Companies.ContactPersons;

namespace SSY.Companies
{
    [Table("AppCompanyContactPersonKeys")]
    public class CompanyContactPersonKey : Entity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        public int ContactPersonId { get; set; }
        [ForeignKey(nameof(ContactPersonId))]
        public ContactPerson ContactPerson { get; set; }

        public CompanyContactPersonKey()
        {
        }

        public CompanyContactPersonKey(int tenantId, bool isActive, int companyId, int contactPersonId)
        {
            TenantId = tenantId;
            IsActive = isActive;
            CompanyId = companyId;
            ContactPersonId = contactPersonId;
        }
    }
}

