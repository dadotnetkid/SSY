using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Companies.ContactPersons;
using Volo.Abp.Data;

namespace SSY.Companies
{
    public class CompanyManager : DomainService, ICompanyManager
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<ContactPerson> _contactPersonRepository;
        private readonly IRepository<CompanyContactPersonKey, Guid> _companyContactPersonKeyRepository;
        private readonly IRepository<CompanyTypeKey, Guid> _companyTypeKeyRepository;
        private readonly IRepository<CompanyMaterialTypeKey, Guid> _companyMaterialTypeKeyRepository;
        private readonly IRepository<CompanyExcessReminderKey, Guid> _companyExcessReminderKeyRepository;

        public CompanyManager(
            IRepository<CompanyExcessReminderKey, Guid> companyExcessReminderKeyRepository,
            IRepository<CompanyMaterialTypeKey, Guid> companyMaterialTypeKeyRepository,
            IRepository<CompanyTypeKey, Guid> companyTypeKeyRepository,
            IRepository<CompanyContactPersonKey, Guid> companyContactPersonKeyRepository,
            IRepository<ContactPerson> contactPersonRepository,
            IRepository<Company> companyRepository)
        {
            _companyExcessReminderKeyRepository = companyExcessReminderKeyRepository;
            _companyMaterialTypeKeyRepository = companyMaterialTypeKeyRepository;
            _companyTypeKeyRepository = companyTypeKeyRepository;
            _companyContactPersonKeyRepository = companyContactPersonKeyRepository;
            _contactPersonRepository = contactPersonRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateAsync(Company company, List<ContactPerson> contactPersons, List<int> companyTypeIds, List<Month> companyExcessReminderIds, List<int> companyMaterialTypeIds)
        {
            // Get All Company
            var companies = await (await _companyRepository.WithDetailsAsync()).IgnoreQueryFilters()
                .OrderBy(x => x.Id)
                .ToListAsync();

            // Assign Company Id
            company.SetProperty("Id", companies.Count + 1);

            // Generate Company Code
            var country = company.Country.ToUpper();
            var city = company.City.Substring(0, 3).ToUpper();
            company.Code = $@"{company.ShortCode}-{country}-{city}-{companies.Count + 1}";

            var createdCompany = await _companyRepository.InsertAsync(company);

            int counter = createdCompany.Id;

            contactPersons.ForEach(async contactPerson =>
            {

                contactPerson.SetProperty("Id", int.Parse($"{createdCompany.Id}{counter}"));

                await _contactPersonRepository.InsertAsync(contactPerson);

                await _companyContactPersonKeyRepository.InsertAsync(new(createdCompany.TenantId, createdCompany.IsActive, createdCompany.Id, contactPerson.Id));

                counter++;
            });

            companyTypeIds.ForEach(async typeId => await _companyTypeKeyRepository.InsertAsync(new(createdCompany.TenantId, createdCompany.IsActive, createdCompany.Id, typeId)));

            companyExcessReminderIds.ForEach(async companyExcessReminderId => await _companyExcessReminderKeyRepository.InsertAsync(new(createdCompany.TenantId, createdCompany.IsActive, createdCompany.Id, companyExcessReminderId)));

            companyMaterialTypeIds.ForEach(async companyMaterialId => await _companyMaterialTypeKeyRepository.InsertAsync(new(createdCompany.TenantId, createdCompany.IsActive, createdCompany.Id, companyMaterialId)));

            //await CurrentUnitOfWork.SaveChangesAsync();

            return createdCompany;
        }

        public async Task<Company> UpdateAsync(Company company, List<ContactPerson> contactPersons, List<int> companyTypeIds, List<Month> companyExcessReminderIds, List<int> companyMaterialTypeIds)
        {
            var updatedCompany = await _companyRepository.UpdateAsync(company);

            int counter = company.Id;

            //Delete All Current ContactPersonKey
            var currentContactPersons = await _companyContactPersonKeyRepository.GetListAsync(x => x.CompanyId == company.Id);
            currentContactPersons.ForEach(async x =>
            {
                await _companyContactPersonKeyRepository.DeleteAsync(x.Id);

                await _contactPersonRepository.HardDeleteAsync(c => c.Id == x.ContactPersonId);
            });

            //   await CurrentUnitOfWork.SaveChangesAsync();

            // Insert new ContactPerson
            contactPersons.ForEach(async contactPerson =>
            {
                //contactPerson.Id = int.Parse($"{company.Id}{counter}");

                await _contactPersonRepository.InsertAsync(contactPerson);

                await _companyContactPersonKeyRepository.InsertAsync(new(company.TenantId, company.IsActive, company.Id, contactPerson.Id));

                counter++;
            });

            // Delete All Current CompanyType
            var currentTypeIds = await _companyTypeKeyRepository.GetListAsync(x => x.CompanyId == company.Id);
            currentTypeIds.ForEach(async typeId => await _companyTypeKeyRepository.DeleteAsync(typeId));

            // Insert New CompanyType
            companyTypeIds.ForEach(async typeId => await _companyTypeKeyRepository.InsertAsync(new(company.TenantId, company.IsActive, company.Id, typeId)));

            // Delete All Current CompanyExcessReminder
            var currentCompanyExcessReminderIds = await _companyExcessReminderKeyRepository.GetListAsync(x => x.CompanyId == company.Id);
            currentCompanyExcessReminderIds.ForEach(async companyExcessReminderId => await _companyExcessReminderKeyRepository.DeleteAsync(companyExcessReminderId));

            // Insert New CompanyExcessReminder
            companyExcessReminderIds.ForEach(async companyExcessReminderId => await _companyExcessReminderKeyRepository.InsertAsync(new(company.TenantId, company.IsActive, company.Id, companyExcessReminderId)));

            // Delete All Current CompanyMaterialType
            var currentCompanyMaterialTypeIds = await _companyMaterialTypeKeyRepository.GetListAsync(x => x.CompanyId == company.Id);
            currentCompanyMaterialTypeIds.ForEach(async companyMaterialId => await _companyMaterialTypeKeyRepository.DeleteAsync(companyMaterialId));

            // Insert New CompanyMaterialType
            companyMaterialTypeIds.ForEach(async companyMaterialId => await _companyMaterialTypeKeyRepository.InsertAsync(new(company.TenantId, company.IsActive, company.Id, companyMaterialId)));

            // await CurrentUnitOfWork.SaveChangesAsync();

            return updatedCompany;

        }

    }
}

