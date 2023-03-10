using System;

namespace SSY.Companies
{
	[Table("AppCompanyTypeKeys")]
	public class CompanyTypeKey : Entity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        public int TypeId { get; set; }

        public CompanyTypeKey()
		{
		}

        public CompanyTypeKey(int tenantId, bool isActive, int companyId, int typeId)
        {
  
            TenantId = tenantId;
            IsActive = isActive;
            CompanyId = companyId;
            TypeId = typeId;
        }
    }
}

