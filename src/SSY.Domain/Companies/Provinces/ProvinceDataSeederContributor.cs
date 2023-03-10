/*using System;
using System.Threading.Tasks;
using SSY.Companies.Provinces;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies.Countries
{
    public class ProvinceDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Province, int> _provinceRepository;

        public ProvinceDataSeederContributor(IRepository<Province, int> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _provinceRepository.GetCountAsync() <= 0)
            {
                var provinces = await _provinceRepository.GetQueryableAsync();

                var AL = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AL");
                if (AL == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "AL",
                        CountryCode = "US",
                        Name = "Alabama",
                        OrderNumber = 1001
                    };

                    AL = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var AK = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AK");
                if (AK == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "AK",
                        CountryCode = "US",
                        Name = "Alaska",
                        OrderNumber = 1002
                    };

                    AK = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var AZ = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AZ");
                if (AZ == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "AZ",
                        CountryCode = "US",
                        Name = "Arizona",
                        OrderNumber = 1003
                    };

                    AZ = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var AR = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AR");
                if (AR == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "AR",
                        CountryCode = "US",
                        Name = "Arkansas",
                        OrderNumber = 1004
                    };

                    AR = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var CA = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CA");
                if (CA == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "CA",
                        CountryCode = "US",
                        Name = "California",
                        OrderNumber = 1004
                    };

                    CA = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var CO = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CO");
                if (CO == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "CO",
                        CountryCode = "US",
                        Name = "Colorado",
                        OrderNumber = 1004
                    };

                    CO = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var CT = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CT");
                if (CT == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "CT",
                        CountryCode = "US",
                        Name = "Connecticut",
                        OrderNumber = 1005
                    };

                    CT = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var DC = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DC");
                if (DC == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "DC",
                        CountryCode = "US",
                        Name = "Washington D.C",
                        OrderNumber = 1005
                    };

                    DC = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var DE = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DE");
                if (DE == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "DE",
                        CountryCode = "US",
                        Name = "Delaware",
                        OrderNumber = 1006
                    };

                    DE = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var FL = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FL");
                if (FL == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "FL",
                        CountryCode = "US",
                        Name = "Florida",
                        OrderNumber = 1007
                    };

                    FL = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var GA = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GA");
                if (GA == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "GA",
                        CountryCode = "US",
                        Name = "Georgia",
                        OrderNumber = 1008
                    };

                    GA = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var HI = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HI");
                if (HI == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "HI",
                        CountryCode = "US",
                        Name = "Hawaii",
                        OrderNumber = 1009
                    };

                    HI = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var ID = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ID");
                if (ID == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "ID",
                        CountryCode = "US",
                        Name = "Idaho",
                        OrderNumber = 1010
                    };

                    ID = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var IL = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IL");
                if (IL == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "IL",
                        CountryCode = "US",
                        Name = "Illinois",
                        OrderNumber = 1011
                    };

                    IL = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var IN = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IN");
                if (IN == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "IN",
                        CountryCode = "US",
                        Name = "Indiana",
                        OrderNumber = 1012
                    };

                    IN = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var IA = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IA");
                if (IA == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "IA",
                        CountryCode = "US",
                        Name = "Iowa",
                        OrderNumber = 1013
                    };

                    IA = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var KS = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KS");
                if (KS == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "KS",
                        CountryCode = "US",
                        Name = "Kansas",
                        OrderNumber = 1014
                    };

                    KS = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var KY = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KY");
                if (KY == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "KY",
                        CountryCode = "US",
                        Name = "Kentucky",
                        OrderNumber = 1015
                    };

                    KY = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var LA = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LA");
                if (LA == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "LA",
                        CountryCode = "US",
                        Name = "Louisiana",
                        OrderNumber = 1016
                    };

                    LA = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var ME = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ME");
                if (ME == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "ME",
                        CountryCode = "US",
                        Name = "Maine",
                        OrderNumber = 1017
                    };

                    ME = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MD = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MD");
                if (MD == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MD",
                        CountryCode = "US",
                        Name = "Maryland",
                        OrderNumber = 1017
                    };

                    MD = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MA = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MA");
                if (MA == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MA",
                        CountryCode = "US",
                        Name = "Massachusetts",
                        OrderNumber = 1018
                    };

                    MA = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MI = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MI");
                if (MI == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MI",
                        CountryCode = "US",
                        Name = "Michigan",
                        OrderNumber = 1019
                    };

                    MI = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MN = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MN");
                if (MN == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MN",
                        CountryCode = "US",
                        Name = "Minnesota",
                        OrderNumber = 1020
                    };

                    MN = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MS = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MS");
                if (MS == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MS",
                        CountryCode = "US",
                        Name = "Mississippi",
                        OrderNumber = 1021
                    };

                    MN = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MO = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MO");
                if (MO == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MO",
                        CountryCode = "US",
                        Name = "Missouri",
                        OrderNumber = 1022
                    };

                    MO = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var MT = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MT");
                if (MT == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "MT",
                        CountryCode = "US",
                        Name = "Montana",
                        OrderNumber = 1023
                    };

                    MT = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var NE = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NE");
                if (NE == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "NE",
                        CountryCode = "US",
                        Name = "Nebraska",
                        OrderNumber = 1024
                    };

                    NE = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var NV = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NV");
                if (NV == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "NV",
                        CountryCode = "US",
                        Name = "Nevada",
                        OrderNumber = 1025
                    };

                    NV = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var NH = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NH");
                if (NH == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "NH",
                        CountryCode = "US",
                        Name = "New Hampshire",
                        OrderNumber = 1025
                    };

                    NH = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

                var NJ = provinces.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NJ");
                if (NJ == null)
                {
                    var province = new Province
                    {

                        IsActive = true,
                        Code = "NJ",
                        CountryCode = "US",
                        Name = "New Jersey",
                        OrderNumber = 1026
                    };

                    NJ = await _provinceRepository.InsertAsync(province, autoSave: true);

                }

            }
        }
    }
}

*/