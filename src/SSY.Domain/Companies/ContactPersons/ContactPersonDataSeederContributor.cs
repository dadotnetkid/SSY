/*using System;
using System.Threading.Tasks;
using SSY.Companies.Cities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies.ContactPersons
{
    public class ContactPersonDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<ContactPerson, int> _contactPersonRepository;

        public ContactPersonDataSeederContributor(IRepository<ContactPerson, int> contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _contactPersonRepository.GetCountAsync() <= 0)
            {

                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Carol Ge", "Merchandiser", "carol.ge@tienhu.com", "13377766901", "13377766901"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Rene Huyo-A", "Manager", "rene_huyoa@yuenthai.com", "+63 (32) 3409434", "+63 915 511 4902"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Joseph Roel Arnoco", "Excess Fabric Representative", "josephroel_arnoco@pi.luenthai.com", "7194", "0995-943-1151"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Hope Martinez Atillo", "YTY Development and Production OIC", "hope_atillo@ytydigital.com", "+6332 4940900-800 loc.2301", "9178369771"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Kelvin Cheung", "Sales Manager", "singfung@biznetvigator.com", "+852 2776 7898", "+852 2776 7898"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Anna Kriska", "Sales", "a-menguito@ykk.com", "(+632) 8807-8875", "(+63) 917 70​1-19​26"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Jenny Jin", "Supervisor", "jenny@trend-textile.com", "(+86)-21-5473-6068", "(+86)-177-2131-6510"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Wilson Fiona", "Sales(Overseas Sales Dept.)", "fiona.duan@wilson-acc.com", "020-86848669  ext. 3185", "020-86848669  ext. 3391"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Jennifer", "Account Officer", "trimsseven@miraclesourcing.com.hk", "+852 – 3422 3558", "+852 – 3422 3353"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Nick", "Sales", "nickwong@hoishunknitting.com", "757 - 2738 1062", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Caroline", "Sales", "caroline@smart-shirts.com.cn", "0575-81395903", "+86 17816522365"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Aileen Li", "PYO MP G2 Dept", "Aileen_Li@gjmluenthai.com", "+8620 84873338 Ext. 2518", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Polly Shi", "Sales", "info@bonvan.com", null, "+8615067758365"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Eileen Deng", "Sales", "eileen@offerplasticbag.com", null, "+8615573972370"), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Nick Wong", "Sales", "nickwong@hoishunknitting.com", "+852 24942519", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Peter Leung", "", "peter_leung@gjmluenthai.com", "8620 84873338 Ext.2818", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Tammy Zhang", "", "tammy_zhang@dg.luenthai.com", "0769-86807810", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Tracy Lancaster", "", "tracy_lancaster@yuenthai.com", "855 89 467 463 ext. no. 1113", null), autoSave: true);
                await _contactPersonRepository.InsertAsync(new ContactPerson(1001, 1, true, "Vicenta Ponteras", "Vice-President", "vicenta_ponteras@yuenthai.com", "+855 23 995396 Ext. 1510", null), autoSave: true);
            }
        }
    }
}

*/