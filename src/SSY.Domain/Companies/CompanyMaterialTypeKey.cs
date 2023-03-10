using System;

namespace SSY.Companies;
[Table("AppCompanyMaterialTypeKeys")]
public class CompanyMaterialTypeKey : Entity<Guid>
{
    public int TenantId { get; set; }
    public bool IsActive { get; set; }

    public int CompanyId { get; set; }
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    public int MaterialTypeId { get; set; }

    public CompanyMaterialTypeKey()
	{
	}

    public CompanyMaterialTypeKey(int tenantId, bool isActive, int companyId, int materialTypeId)
    {

        TenantId = tenantId;
        IsActive = isActive;
        CompanyId = companyId;
        MaterialTypeId = materialTypeId;
    }
}

