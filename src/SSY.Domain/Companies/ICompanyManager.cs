using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Companies.ContactPersons;

namespace SSY.Companies
{
    public interface ICompanyManager : IDomainService
    {

        Task<Company> CreateAsync(Company company, List<ContactPerson> contactPersons, List<int> companyTypeIds, List<Month> companyExcessReminderIds, List<int> companyMaterialIds);
        Task<Company> UpdateAsync(Company company, List<ContactPerson> contactPersons, List<int> companyTypeIds, List<Month> companyExcessReminderIds, List<int> companyMaterialTypeIds);
    }
}
