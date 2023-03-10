/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies.Countries
{
    public class CountryDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Country, int> _countryRepository;

        public CountryDataSeederContributor(IRepository<Country, int> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _countryRepository.GetCountAsync() <= 0)
            {
                var countries = await _countryRepository.GetQueryableAsync();

                var AF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AF");
                if (AF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AF",
                        Name = "Afghanistan",
                        MobilePrefix = "+93",
                        OrderNumber = 1001
                    };

                    AF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AL");
                if (AL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AL",
                        Name = "Albania",
                        MobilePrefix = "+355",
                        OrderNumber = 1002
                    };

                    AL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DZ");
                if (DZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DZ",
                        Name = "Algeria",
                        MobilePrefix = "+213",
                        OrderNumber = 1003
                    };

                    DZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AS");
                if (AS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AS",
                        Name = "American Samoa",
                        MobilePrefix = "+1684",
                        OrderNumber = 1004
                    };

                    AS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AD");
                if (AD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AD",
                        Name = "Andorra",
                        MobilePrefix = "+376",
                        OrderNumber = 1005
                    };

                    AD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AO");
                if (AO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AO",
                        Name = "Angola",
                        MobilePrefix = "+244",
                        OrderNumber = 1006
                    };

                    AO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AI");
                if (AI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AI",
                        Name = "Anguilla",
                        MobilePrefix = "+1264",
                        OrderNumber = 1007
                    };

                    AI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AQ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AQ");
                if (AQ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AQ",
                        Name = "Antarctica",
                        MobilePrefix = "+0",
                        OrderNumber = 1008
                    };

                    AQ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AG");
                if (AG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AG",
                        Name = "Antigua and Barbuda",
                        MobilePrefix = "+1268",
                        OrderNumber = 1009
                    };

                    AG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AR");
                if (AR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AR",
                        Name = "Argentina",
                        MobilePrefix = "+54",
                        OrderNumber = 1010
                    };

                    AR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AM");
                if (AM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AM",
                        Name = "Armenia",
                        MobilePrefix = "+374",
                        OrderNumber = 1011
                    };

                    AM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AW");
                if (AW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AW",
                        Name = "Aruba",
                        MobilePrefix = "+297",
                        OrderNumber = 1012
                    };

                    AW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AU");
                if (AU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AU",
                        Name = "Australia",
                        MobilePrefix = "+61",
                        OrderNumber = 1013
                    };

                    AU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AT");
                if (AT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AT",
                        Name = "Austria",
                        MobilePrefix = "+43",
                        OrderNumber = 1014
                    };

                    AT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AZ");
                if (AZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AZ",
                        Name = "Azerbaijan",
                        MobilePrefix = "+994",
                        OrderNumber = 1015
                    };

                    AZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BS");
                if (BS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BS",
                        Name = "Bahamas",
                        MobilePrefix = "+1242",
                        OrderNumber = 1016
                    };

                    BS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BH");
                if (BH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BH",
                        Name = "Bahrain",
                        MobilePrefix = "+973",
                        OrderNumber = 1017
                    };

                    BH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BD");
                if (BD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BD",
                        Name = "Bangladesh",
                        MobilePrefix = "+880",
                        OrderNumber = 1018
                    };

                    BD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BB = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BB");
                if (BB == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BB",
                        Name = "Barbados",
                        MobilePrefix = "+1246",
                        OrderNumber = 1019
                    };

                    BB = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BY");
                if (BY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BY",
                        Name = "Belarus",
                        MobilePrefix = "+375",
                        OrderNumber = 1020
                    };

                    BY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BE");
                if (BE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BE",
                        Name = "Belgium",
                        MobilePrefix = "+32",
                        OrderNumber = 1021
                    };

                    BE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BZ");
                if (BZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BZ",
                        Name = "Belize",
                        MobilePrefix = "+501",
                        OrderNumber = 1022
                    };

                    BZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BJ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BJ");
                if (BJ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BJ",
                        Name = "Benin",
                        MobilePrefix = "+229",
                        OrderNumber = 1023
                    };

                    BJ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BM");
                if (BM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BM",
                        Name = "Bermuda",
                        MobilePrefix = "+1441",
                        OrderNumber = 1024
                    };

                    BM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BT");
                if (BT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BT",
                        Name = "Bhutan",
                        MobilePrefix = "+975",
                        OrderNumber = 1025
                    };

                    BT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BO");
                if (BO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BO",
                        Name = "Bolivia",
                        MobilePrefix = "+591",
                        OrderNumber = 1026
                    };

                    BO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BA");
                if (BA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BA",
                        Name = "Bosnia and Herzegovina",
                        MobilePrefix = "+387",
                        OrderNumber = 1027
                    };

                    BA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BW");
                if (BW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BW",
                        Name = "Botswana",
                        MobilePrefix = "+267",
                        OrderNumber = 1028
                    };

                    BW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BV");
                if (BV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BV",
                        Name = "Bouvet Island",
                        MobilePrefix = "+0",
                        OrderNumber = 1029
                    };

                    BV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BR");
                if (BR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BR",
                        Name = "Brazil",
                        MobilePrefix = "+55",
                        OrderNumber = 1030
                    };

                    BR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IO");
                if (IO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IO",
                        Name = "British Indian Ocean Territory",
                        MobilePrefix = "+246",
                        OrderNumber = 1031
                    };

                    IO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BN");
                if (BN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BN",
                        Name = "Brunei Darussalam",
                        MobilePrefix = "+673",
                        OrderNumber = 1032
                    };

                    BN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BG");
                if (BG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BG",
                        Name = "Bulgaria",
                        MobilePrefix = "+673",
                        OrderNumber = 1033
                    };

                    BG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BF");
                if (BF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BF",
                        Name = "Burkina Faso",
                        MobilePrefix = "+226",
                        OrderNumber = 1034
                    };

                    BF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var BI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "BI");
                if (BI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "BI",
                        Name = "Burundi",
                        MobilePrefix = "+257",
                        OrderNumber = 1035
                    };

                    BI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KH");
                if (KH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KH",
                        Name = "Cambodia",
                        MobilePrefix = "+855",
                        OrderNumber = 1036
                    };

                    KH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CM");
                if (CM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CM",
                        Name = "Cameroon",
                        MobilePrefix = "+237",
                        OrderNumber = 1037
                    };

                    CM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CA");
                if (CA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CA",
                        Name = "Canada",
                        MobilePrefix = "+1",
                        OrderNumber = 1038
                    };

                    CA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CV");
                if (CV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CV",
                        Name = "Cape Verde",
                        MobilePrefix = "+238",
                        OrderNumber = 1039
                    };

                    CV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KY");
                if (KY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KY",
                        Name = "Cayman Islands",
                        MobilePrefix = "+1345",
                        OrderNumber = 1040
                    };

                    KY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CF");
                if (CF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CF",
                        Name = "Central African Republic",
                        MobilePrefix = "+236",
                        OrderNumber = 1041
                    };

                    CF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TD");
                if (TD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TD",
                        Name = "Chad",
                        MobilePrefix = "+235",
                        OrderNumber = 1042
                    };

                    TD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CL");
                if (CL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CL",
                        Name = "Chile",
                        MobilePrefix = "+56",
                        OrderNumber = 1043
                    };

                    CL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CN");
                if (CN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CN",
                        Name = "China",
                        MobilePrefix = "+86",
                        OrderNumber = 1044
                    };

                    CN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CX = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CX");
                if (CX == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CX",
                        Name = "Christmas Island",
                        MobilePrefix = "+61",
                        OrderNumber = 1045
                    };

                    CX = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CC");
                if (CC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CC",
                        Name = "Cocos (Keeling) Islands",
                        MobilePrefix = "+672",
                        OrderNumber = 1046
                    };

                    CC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CO");
                if (CO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CO",
                        Name = "Colombia",
                        MobilePrefix = "+57",
                        OrderNumber = 1047
                    };

                    CO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KM");
                if (KM == null)
                {
                    var country = new Country
                    {
                        Code = "KM",
                        Name = "Comoros",
                        MobilePrefix = "+269",
                        OrderNumber = 1048
                    };

                    KM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CG");
                if (CG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CG",
                        Name = "Congo",
                        MobilePrefix = "+242",
                        OrderNumber = 1049
                    };

                    CG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CD");
                if (CD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CD",
                        Name = "Congo, the Democratic Republic of the",
                        MobilePrefix = "+242",
                        OrderNumber = 1050
                    };

                    CD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CK");
                if (CK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CK",
                        Name = "Cook Islands",
                        MobilePrefix = "+682",
                        OrderNumber = 1051
                    };

                    CK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CR");
                if (CR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CR",
                        Name = "Costa Rica",
                        MobilePrefix = "+506",
                        OrderNumber = 1052
                    };

                    CR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CI");
                if (CI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CI",
                        Name = "Cote D''Ivoire",
                        MobilePrefix = "+225",
                        OrderNumber = 1053
                    };

                    CI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HR");
                if (HR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HR",
                        Name = "Croatia",
                        MobilePrefix = "+385",
                        OrderNumber = 1054
                    };

                    HR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CU");
                if (CU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CU",
                        Name = "Cuba",
                        MobilePrefix = "+53",
                        OrderNumber = 1055
                    };

                    CU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CY");
                if (CY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CY",
                        Name = "Cyprus",
                        MobilePrefix = "+357",
                        OrderNumber = 1056
                    };

                    CY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CZ");
                if (CZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CZ",
                        Name = "Czech Republic",
                        MobilePrefix = "+420",
                        OrderNumber = 1057
                    };

                    CZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DK");
                if (DK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DK",
                        Name = "Denmark",
                        MobilePrefix = "+420",
                        OrderNumber = 1058
                    };

                    DK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DJ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DJ");
                if (DJ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DJ",
                        Name = "Djibouti",
                        MobilePrefix = "+253",
                        OrderNumber = 1059
                    };

                    DJ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DM");
                if (DM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DM",
                        Name = "Dominica",
                        MobilePrefix = "+1767",
                        OrderNumber = 1060
                    };

                    DM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DO");
                if (DO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DO",
                        Name = "Dominican Republic",
                        MobilePrefix = "+1809",
                        OrderNumber = 1061
                    };

                    DO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var EC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "EC");
                if (EC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "EC",
                        Name = "Ecuador",
                        MobilePrefix = "+593",
                        OrderNumber = 1062
                    };

                    EC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var EG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "EG");
                if (EG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "EG",
                        Name = "Egypt",
                        MobilePrefix = "+20",
                        OrderNumber = 1063
                    };

                    EG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SV");
                if (SV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SV",
                        Name = "El Salvador",
                        MobilePrefix = "+503",
                        OrderNumber = 1064
                    };

                    SV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GQ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GQ");
                if (GQ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GQ",
                        Name = "Equatorial Guinea",
                        MobilePrefix = "+240",
                        OrderNumber = 1065
                    };

                    GQ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ER = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ER");
                if (ER == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ER",
                        Name = "Eritrea",
                        MobilePrefix = "+291",
                        OrderNumber = 1066
                    };

                    ER = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var EE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "EE");
                if (EE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "EE",
                        Name = "Estonia",
                        MobilePrefix = "+372",
                        OrderNumber = 1067
                    };

                    EE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ET = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ET");
                if (ET == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ET",
                        Name = "Ethiopia",
                        MobilePrefix = "+251",
                        OrderNumber = 1068
                    };

                    ET = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FK");
                if (FK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FK",
                        Name = "Falkland Islands (Malvinas)",
                        MobilePrefix = "+251",
                        OrderNumber = 1069
                    };

                    FK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FO");
                if (FO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FO",
                        Name = "Faroe Islands",
                        MobilePrefix = "+298",
                        OrderNumber = 1070
                    };

                    FO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FJ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FJ");
                if (FJ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FJ",
                        Name = "Fiji",
                        MobilePrefix = "+679",
                        OrderNumber = 1071
                    };

                    FJ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FI");
                if (FI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FI",
                        Name = "Finland",
                        MobilePrefix = "+358",
                        OrderNumber = 1072
                    };

                    FI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FR");
                if (FR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FR",
                        Name = "France",
                        MobilePrefix = "+33",
                        OrderNumber = 1073
                    };

                    FR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GF");
                if (GF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GF",
                        Name = "French Guiana",
                        MobilePrefix = "+594",
                        OrderNumber = 1074
                    };

                    GF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PF");
                if (PF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PF",
                        Name = "French Polynesia",
                        MobilePrefix = "+689",
                        OrderNumber = 1075
                    };

                    PF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TF");
                if (TF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TF",
                        Name = "French Southern Territories",
                        MobilePrefix = "+0",
                        OrderNumber = 1076
                    };

                    TF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GA");
                if (GA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GA",
                        Name = "Gabon",
                        MobilePrefix = "+241",
                        OrderNumber = 1077
                    };

                    GA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GM");
                if (GM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GM",
                        Name = "Gambia",
                        MobilePrefix = "+220",
                        OrderNumber = 1078
                    };

                    GM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GE");
                if (GE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GE",
                        Name = "Georgia",
                        MobilePrefix = "+995",
                        OrderNumber = 1079
                    };

                    GE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var DE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "DE");
                if (DE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "DE",
                        Name = "Germany",
                        MobilePrefix = "+995",
                        OrderNumber = 1080
                    };

                    DE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GH");
                if (GH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GH",
                        Name = "Ghana",
                        MobilePrefix = "+233",
                        OrderNumber = 1081
                    };

                    GH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GI");
                if (GI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GI",
                        Name = "Gibraltar",
                        MobilePrefix = "+350",
                        OrderNumber = 1082
                    };

                    GI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GR");
                if (GR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GR",
                        Name = "Greece",
                        MobilePrefix = "+30",
                        OrderNumber = 1083
                    };

                    GR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GL");
                if (GL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GL",
                        Name = "Greenland",
                        MobilePrefix = "+299",
                        OrderNumber = 1084
                    };

                    GL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GD");
                if (GD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GD",
                        Name = "Grenada",
                        MobilePrefix = "+1473",
                        OrderNumber = 1085
                    };

                    GD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GP = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GP");
                if (GP == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GP",
                        Name = "Guadeloupe",
                        MobilePrefix = "+590",
                        OrderNumber = 1086
                    };

                    GP = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GU");
                if (GU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GU",
                        Name = "Guam",
                        MobilePrefix = "+1671",
                        OrderNumber = 1087
                    };

                    GU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GT");
                if (GT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GT",
                        Name = "Guatemala",
                        MobilePrefix = "+502",
                        OrderNumber = 1088
                    };

                    GT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GN");
                if (GN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GN",
                        Name = "Guinea",
                        MobilePrefix = "+224",
                        OrderNumber = 1089
                    };

                    GN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GW");
                if (GW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GW",
                        Name = "Guinea-Bissau",
                        MobilePrefix = "+245",
                        OrderNumber = 1090
                    };

                    GW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GY");
                if (GY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GY",
                        Name = "Guyana",
                        MobilePrefix = "+592",
                        OrderNumber = 1091
                    };

                    GY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HT");
                if (HT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HT",
                        Name = "Haiti",
                        MobilePrefix = "+509",
                        OrderNumber = 1092
                    };

                    HT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HM");
                if (HM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HM",
                        Name = "Heard Island and Mcdonald Islands",
                        MobilePrefix = "+0",
                        OrderNumber = 1093
                    };

                    HM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VA");
                if (VA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VA",
                        Name = "Holy See (Vatican City State)",
                        MobilePrefix = "+39",
                        OrderNumber = 1094
                    };

                    VA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HN");
                if (HN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HN",
                        Name = "Honduras",
                        MobilePrefix = "+504",
                        OrderNumber = 1095
                    };

                    HN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HK");
                if (HK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HK",
                        Name = "Hong Kong",
                        MobilePrefix = "+852",
                        OrderNumber = 1096
                    };

                    HK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var HU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "HU");
                if (HU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "HU",
                        Name = "Hungary",
                        MobilePrefix = "+36",
                        OrderNumber = 1097
                    };

                    HU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IS");
                if (IS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IS",
                        Name = "Iceland",
                        MobilePrefix = "+354",
                        OrderNumber = 1098
                    };

                    IS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IN");
                if (IN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IN",
                        Name = "India",
                        MobilePrefix = "+91",
                        OrderNumber = 1099
                    };

                    IN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ID = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ID");
                if (ID == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ID",
                        Name = "Indonesia",
                        MobilePrefix = "+62",
                        OrderNumber = 1100
                    };

                    ID = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IR");
                if (IR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IR",
                        Name = "Iran, Islamic Republic of",
                        MobilePrefix = "+98",
                        OrderNumber = 1101
                    };

                    IR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IQ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IQ");
                if (IQ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IQ",
                        Name = "Iraq",
                        MobilePrefix = "+98",
                        OrderNumber = 1102
                    };

                    IQ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IE");
                if (IE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IE",
                        Name = "Ireland",
                        MobilePrefix = "+353",
                        OrderNumber = 1103
                    };

                    IE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IL");
                if (IL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IL",
                        Name = "Israel",
                        MobilePrefix = "+972",
                        OrderNumber = 1104
                    };

                    IL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var IT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "IT");
                if (IT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "IT",
                        Name = "Italy",
                        MobilePrefix = "+39",
                        OrderNumber = 1105
                    };

                    IT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var JM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "JM");
                if (JM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "JM",
                        Name = "Jamaica",
                        MobilePrefix = "+1876",
                        OrderNumber = 1106
                    };

                    JM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var JP = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "JP");
                if (JP == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "JP",
                        Name = "Japan",
                        MobilePrefix = "+81",
                        OrderNumber = 1107
                    };

                    JP = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var JO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "JO");
                if (JO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "JO",
                        Name = "Jordan",
                        MobilePrefix = "+962",
                        OrderNumber = 1108
                    };

                    JO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KZ");
                if (KZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KZ",
                        Name = "Kazakhstan",
                        MobilePrefix = "+7",
                        OrderNumber = 1109
                    };

                    KZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KE");
                if (KE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KE",
                        Name = "Kenya",
                        MobilePrefix = "+254",
                        OrderNumber = 1110
                    };

                    KE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KI");
                if (KI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KI",
                        Name = "Kiribati",
                        MobilePrefix = "+686",
                        OrderNumber = 1111
                    };

                    KI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KP = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KP");
                if (KP == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KP",
                        Name = "Korea, Democratic People''s Republic of",
                        MobilePrefix = "+850",
                        OrderNumber = 1112
                    };

                    KP = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KR");
                if (KR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KR",
                        Name = "Korea, Republic of",
                        MobilePrefix = "+82",
                        OrderNumber = 1113
                    };

                    KR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KW");
                if (KW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KW",
                        Name = "Kuwait",
                        MobilePrefix = "+965",
                        OrderNumber = 1114
                    };

                    KW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KG");
                if (KG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KG",
                        Name = "Kyrgyzstan",
                        MobilePrefix = "+996",
                        OrderNumber = 1115
                    };

                    KG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LA");
                if (LA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LA",
                        Name = "Lao People''s Democratic Republic",
                        MobilePrefix = "+856",
                        OrderNumber = 1116
                    };

                    LA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LV");
                if (LV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LV",
                        Name = "Latvia",
                        MobilePrefix = "+371",
                        OrderNumber = 1117
                    };

                    LV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LB = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LB");
                if (LB == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LB",
                        Name = "Lebanon",
                        MobilePrefix = "+961",
                        OrderNumber = 1118
                    };

                    LB = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LS");
                if (LS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LS",
                        Name = "Lesotho",
                        MobilePrefix = "+266",
                        OrderNumber = 1119
                    };

                    LS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LR");
                if (LR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LR",
                        Name = "Liberia",
                        MobilePrefix = "+231",
                        OrderNumber = 1120
                    };

                    LR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LY");
                if (LY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LY",
                        Name = "Libyan Arab Jamahiriya",
                        MobilePrefix = "+218",
                        OrderNumber = 1121
                    };

                    LY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LI");
                if (LI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LI",
                        Name = "Liechtenstein",
                        MobilePrefix = "+218",
                        OrderNumber = 1122
                    };

                    LI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LT");
                if (LT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LT",
                        Name = "Lithuania",
                        MobilePrefix = "+370",
                        OrderNumber = 1123
                    };

                    LT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LU");
                if (LU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LU",
                        Name = "Luxembourg",
                        MobilePrefix = "+352",
                        OrderNumber = 1124
                    };

                    LU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MO");
                if (MO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MO",
                        Name = "Macao",
                        MobilePrefix = "+853",
                        OrderNumber = 1125
                    };

                    MO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MK");
                if (MK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MK",
                        Name = "Macedonia, the Former Yugoslav Republic of",
                        MobilePrefix = "+389",
                        OrderNumber = 1126
                    };

                    MK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MG");
                if (MG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MG",
                        Name = "Madagascar",
                        MobilePrefix = "+261",
                        OrderNumber = 1127
                    };

                    MG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MW");
                if (MW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MW",
                        Name = "Malawi",
                        MobilePrefix = "+265",
                        OrderNumber = 1128
                    };

                    MW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MY");
                if (MY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MY",
                        Name = "Malaysia",
                        MobilePrefix = "+60",
                        OrderNumber = 1129
                    };

                    MY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MV");
                if (MV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MV",
                        Name = "Maldives",
                        MobilePrefix = "+960",
                        OrderNumber = 1130
                    };

                    MV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ML = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ML");
                if (ML == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ML",
                        Name = "Mali",
                        MobilePrefix = "+223",
                        OrderNumber = 1131
                    };

                    ML = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MT");
                if (MT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MT",
                        Name = "Malta",
                        MobilePrefix = "+356",
                        OrderNumber = 1132
                    };

                    MT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MH");
                if (MH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MH",
                        Name = "Marshall Islands",
                        MobilePrefix = "+692",
                        OrderNumber = 1133
                    };

                    MH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MQ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MQ");
                if (MQ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MQ",
                        Name = "Martinique",
                        MobilePrefix = "+596",
                        OrderNumber = 1134
                    };

                    MQ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MR");
                if (MR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MR",
                        Name = "Mauritania",
                        MobilePrefix = "+222",
                        OrderNumber = 1135
                    };

                    MR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MU");
                if (MU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MU",
                        Name = "Mauritius",
                        MobilePrefix = "+230",
                        OrderNumber = 1136
                    };

                    MU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var YT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "YT");
                if (YT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "YT",
                        Name = "Mayotte",
                        MobilePrefix = "+269",
                        OrderNumber = 1137
                    };

                    YT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MX = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MX");
                if (MX == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MX",
                        Name = "Mexico",
                        MobilePrefix = "+52",
                        OrderNumber = 1138
                    };

                    MX = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var FM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "FM");
                if (FM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "FM",
                        Name = "Micronesia, Federated States of",
                        MobilePrefix = "+691",
                        OrderNumber = 1139
                    };

                    FM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MD");
                if (MD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MD",
                        Name = "Moldova, Republic of",
                        MobilePrefix = "+373",
                        OrderNumber = 1140
                    };

                    MD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MC");
                if (MC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MC",
                        Name = "Monaco",
                        MobilePrefix = "+377",
                        OrderNumber = 1141
                    };

                    MC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MN");
                if (MN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MN",
                        Name = "Mongolia",
                        MobilePrefix = "+976",
                        OrderNumber = 1142
                    };

                    MN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MS");
                if (MS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MS",
                        Name = "Montserrat",
                        MobilePrefix = "+1664",
                        OrderNumber = 1143
                    };

                    MS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MA");
                if (MA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MA",
                        Name = "Morocco",
                        MobilePrefix = "+212",
                        OrderNumber = 1144
                    };

                    MA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MZ");
                if (MZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MZ",
                        Name = "Mozambique",
                        MobilePrefix = "+258",
                        OrderNumber = 1145
                    };

                    MZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MM");
                if (MM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MM",
                        Name = "Myanmar",
                        MobilePrefix = "+95",
                        OrderNumber = 1146
                    };

                    MM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NA");
                if (NA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NA",
                        Name = "Namibia",
                        MobilePrefix = "+95",
                        OrderNumber = 1147
                    };

                    NA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NR");
                if (NR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NR",
                        Name = "Nauru",
                        MobilePrefix = "+674",
                        OrderNumber = 1148
                    };

                    NR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NP = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NP");
                if (NP == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NP",
                        Name = "Nepal",
                        MobilePrefix = "+977",
                        OrderNumber = 1149
                    };

                    NP = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NL");
                if (NL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NL",
                        Name = "Netherlands",
                        MobilePrefix = "+31",
                        OrderNumber = 1150
                    };

                    NL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AN");
                if (AN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AN",
                        Name = "Netherlands Antilles",
                        MobilePrefix = "+599",
                        OrderNumber = 1151
                    };

                    AN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NC");
                if (NC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NC",
                        Name = "New Caledonia",
                        MobilePrefix = "+687",
                        OrderNumber = 1152
                    };

                    NC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NZ");
                if (NZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NZ",
                        Name = "New Zealand",
                        MobilePrefix = "+64",
                        OrderNumber = 1153
                    };

                    NZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NI");
                if (NI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NI",
                        Name = "Nicaragua",
                        MobilePrefix = "+505",
                        OrderNumber = 1154
                    };

                    NI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NE");
                if (NE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NE",
                        Name = "Niger",
                        MobilePrefix = "+227",
                        OrderNumber = 1155
                    };

                    NE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NG");
                if (NG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NG",
                        Name = "Nigeria",
                        MobilePrefix = "+234",
                        OrderNumber = 1156
                    };

                    NG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NU");
                if (NU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NU",
                        Name = "Niue",
                        MobilePrefix = "+683",
                        OrderNumber = 1157
                    };

                    NU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NF");
                if (NF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NF",
                        Name = "Norfolk Island",
                        MobilePrefix = "+672",
                        OrderNumber = 1158
                    };

                    NF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var MP = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "MP");
                if (MP == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "MP",
                        Name = "Northern Mariana Islands",
                        MobilePrefix = "+1670",
                        OrderNumber = 1159
                    };

                    MP = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var NO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "NO");
                if (NO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "NO",
                        Name = "Norway",
                        MobilePrefix = "+47",
                        OrderNumber = 1160
                    };

                    NO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var OM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "OM");
                if (OM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "OM",
                        Name = "Oman",
                        MobilePrefix = "+968",
                        OrderNumber = 1161
                    };

                    OM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PK");
                if (PK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PK",
                        Name = "Pakistan",
                        MobilePrefix = "+92",
                        OrderNumber = 1162
                    };

                    PK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PW");
                if (PW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PW",
                        Name = "Palau",
                        MobilePrefix = "+680",
                        OrderNumber = 1163
                    };

                    PW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PS");
                if (PS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PS",
                        Name = "Palestinian Territory, Occupied",
                        MobilePrefix = "+970",
                        OrderNumber = 1164
                    };

                    PS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PA");
                if (PA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PA",
                        Name = "Panama",
                        MobilePrefix = "+507",
                        OrderNumber = 1165
                    };

                    PA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PG");
                if (PG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PG",
                        Name = "Papua New Guinea",
                        MobilePrefix = "+675",
                        OrderNumber = 1166
                    };

                    PG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PY");
                if (PY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PY",
                        Name = "Paraguay",
                        MobilePrefix = "+595",
                        OrderNumber = 1167
                    };

                    PY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PE");
                if (PE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PE",
                        Name = "Peru",
                        MobilePrefix = "+51",
                        OrderNumber = 1168
                    };

                    PE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PH");
                if (PH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PH",
                        Name = "Philippines",
                        MobilePrefix = "+63",
                        OrderNumber = 1169
                    };

                    PH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PN");
                if (PN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PN",
                        Name = "Pitcairn",
                        MobilePrefix = "+0",
                        OrderNumber = 1170
                    };

                    PN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PL");
                if (PL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PL",
                        Name = "Poland",
                        MobilePrefix = "+48",
                        OrderNumber = 1171
                    };

                    PL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PT");
                if (PT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PT",
                        Name = "Portugal",
                        MobilePrefix = "+351",
                        OrderNumber = 1172
                    };

                    PT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PR");
                if (PR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PR",
                        Name = "Puerto Rico",
                        MobilePrefix = "+1787",
                        OrderNumber = 1173
                    };

                    PR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var QA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "QA");
                if (QA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "QA",
                        Name = "Qatar",
                        MobilePrefix = "+974",
                        OrderNumber = 1174
                    };

                    QA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var RE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "RE");
                if (RE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "RE",
                        Name = "Reunion",
                        MobilePrefix = "+262",
                        OrderNumber = 1175
                    };

                    RE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var RO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "RO");
                if (RO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "RO",
                        Name = "Romania",
                        MobilePrefix = "+40",
                        OrderNumber = 1176
                    };

                    RO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var RU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "RU");
                if (RU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "RU",
                        Name = "Russian Federation",
                        MobilePrefix = "+70",
                        OrderNumber = 1177
                    };

                    RU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var RW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "RW");
                if (RW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "RW",
                        Name = "Rwanda",
                        MobilePrefix = "+250",
                        OrderNumber = 1178
                    };

                    RW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SH");
                if (SH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SH",
                        Name = "Saint Helena",
                        MobilePrefix = "+290",
                        OrderNumber = 1179
                    };

                    SH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var KN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "KN");
                if (KN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "KN",
                        Name = "Saint Kitts and Nevis",
                        MobilePrefix = "+1869",
                        OrderNumber = 1180
                    };

                    KN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LC");
                if (LC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LC",
                        Name = "Saint Lucia",
                        MobilePrefix = "+1758",
                        OrderNumber = 1181
                    };

                    LC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var PM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "PM");
                if (PM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "PM",
                        Name = "Saint Pierre and Miquelon",
                        MobilePrefix = "+508",
                        OrderNumber = 1182
                    };

                    PM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VC");
                if (VC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VC",
                        Name = "Saint Vincent and the Grenadines",
                        MobilePrefix = "+1784",
                        OrderNumber = 1183
                    };

                    VC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var WS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "WS");
                if (WS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "WS",
                        Name = "Samoa",
                        MobilePrefix = "+684",
                        OrderNumber = 1184
                    };

                    WS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SM");
                if (SM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SM",
                        Name = "San Marino",
                        MobilePrefix = "+378",
                        OrderNumber = 1185
                    };

                    SM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ST = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ST");
                if (ST == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ST",
                        Name = "Sao Tome and Principe",
                        MobilePrefix = "+239",
                        OrderNumber = 1186
                    };

                    ST = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SA");
                if (SA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SA",
                        Name = "Saudi Arabia",
                        MobilePrefix = "+966",
                        OrderNumber = 1187
                    };

                    SA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SN");
                if (SN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SN",
                        Name = "Senegal",
                        MobilePrefix = "+221",
                        OrderNumber = 1188
                    };

                    SN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CS");
                if (CS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CS",
                        Name = "Serbia and Montenegro",
                        MobilePrefix = "+381",
                        OrderNumber = 1189
                    };

                    CS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SC");
                if (SC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SC",
                        Name = "Seychelles",
                        MobilePrefix = "+248",
                        OrderNumber = 1190
                    };

                    SC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SL");
                if (SL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SL",
                        Name = "Sierra Leone",
                        MobilePrefix = "+232",
                        OrderNumber = 1191
                    };

                    SL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SG");
                if (SG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SG",
                        Name = "Singapore",
                        MobilePrefix = "+65",
                        OrderNumber = 1192
                    };

                    SG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SK");
                if (SK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SK",
                        Name = "Slovakia",
                        MobilePrefix = "+421",
                        OrderNumber = 1193
                    };

                    SK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SI");
                if (SI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SI",
                        Name = "Slovenia",
                        MobilePrefix = "+386",
                        OrderNumber = 1194
                    };

                    SI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SB = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SB");
                if (SB == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SB",
                        Name = "Solomon Islands",
                        MobilePrefix = "+677",
                        OrderNumber = 1195
                    };

                    SB = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SO");
                if (SO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SO",
                        Name = "Somalia",
                        MobilePrefix = "+252",
                        OrderNumber = 1196
                    };

                    SO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ZA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ZA");
                if (ZA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ZA",
                        Name = "South Africa",
                        MobilePrefix = "+27",
                        OrderNumber = 1197
                    };

                    ZA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GS = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GS");
                if (GS == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GS",
                        Name = "South Georgia and the South Sandwich Islands",
                        MobilePrefix = "+0",
                        OrderNumber = 1198
                    };

                    GS = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ES = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ES");
                if (ES == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ES",
                        Name = "Spain",
                        MobilePrefix = "+34",
                        OrderNumber = 1199
                    };

                    ES = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var LK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "LK");
                if (LK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "LK",
                        Name = "Sri Lanka",
                        MobilePrefix = "+94",
                        OrderNumber = 1200
                    };

                    LK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SD = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SD");
                if (SD == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SD",
                        Name = "Sudan",
                        MobilePrefix = "+249",
                        OrderNumber = 1201
                    };

                    SD = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SR");
                if (SR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SR",
                        Name = "Suriname",
                        MobilePrefix = "+597",
                        OrderNumber = 1202
                    };

                    SR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SJ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SJ");
                if (SJ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SJ",
                        Name = "Svalbard and Jan Mayen",
                        MobilePrefix = "+47",
                        OrderNumber = 1203
                    };

                    SJ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SZ");
                if (SZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SZ",
                        Name = "Swaziland",
                        MobilePrefix = "+268",
                        OrderNumber = 1204
                    };

                    SZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SE");
                if (SE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SE",
                        Name = "Sweden",
                        MobilePrefix = "+46",
                        OrderNumber = 1205
                    };

                    SE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var CH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "CH");
                if (CH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "CH",
                        Name = "Switzerland",
                        MobilePrefix = "+41",
                        OrderNumber = 1206
                    };

                    CH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var SY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "SY");
                if (SY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "SY",
                        Name = "Syrian Arab Republic",
                        MobilePrefix = "+963",
                        OrderNumber = 1207
                    };

                    SY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TW");
                if (TW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TW",
                        Name = "Taiwan, Province of China",
                        MobilePrefix = "+886",
                        OrderNumber = 1208
                    };

                    TW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TJ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TJ");
                if (TJ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TJ",
                        Name = "Tajikistan",
                        MobilePrefix = "+992",
                        OrderNumber = 1209
                    };

                    TJ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TZ");
                if (TZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TZ",
                        Name = "Tanzania, United Republic of",
                        MobilePrefix = "+255",
                        OrderNumber = 1210
                    };

                    TZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TH");
                if (TH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TH",
                        Name = "Thailand",
                        MobilePrefix = "+66",
                        OrderNumber = 1211
                    };

                    TH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TL = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TL");
                if (TL == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TL",
                        Name = "Timor-Leste",
                        MobilePrefix = "+670",
                        OrderNumber = 1212
                    };

                    TL = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TG");
                if (TG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TG",
                        Name = "Togo",
                        MobilePrefix = "+228",
                        OrderNumber = 1213
                    };

                    TG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TK = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TK");
                if (TK == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TK",
                        Name = "Tokelau",
                        MobilePrefix = "+690",
                        OrderNumber = 1214
                    };

                    TK = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TO = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TO");
                if (TO == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TO",
                        Name = "Tonga",
                        MobilePrefix = "+676",
                        OrderNumber = 1215
                    };

                    TO = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TT = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TT");
                if (TT == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TT",
                        Name = "Trinidad and Tobago",
                        MobilePrefix = "+1868",
                        OrderNumber = 1216
                    };

                    TT = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TN");
                if (TN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TN",
                        Name = "Tunisia",
                        MobilePrefix = "+216",
                        OrderNumber = 1217
                    };

                    TN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TR = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TR");
                if (TR == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TR",
                        Name = "Turkey",
                        MobilePrefix = "+90",
                        OrderNumber = 1218
                    };

                    TR = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TM");
                if (TM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TM",
                        Name = "Turkmenistan",
                        MobilePrefix = "+7370",
                        OrderNumber = 1219
                    };

                    TM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TC = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TC");
                if (TC == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TC",
                        Name = "Turks and Caicos Islands",
                        MobilePrefix = "+1649",
                        OrderNumber = 1220
                    };

                    TC = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var TV = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "TV");
                if (TV == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "TV",
                        Name = "Tuvalu",
                        MobilePrefix = "+688",
                        OrderNumber = 1221
                    };

                    TV = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var UG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "UG");
                if (UG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "UG",
                        Name = "Uganda",
                        MobilePrefix = "+256",
                        OrderNumber = 1222
                    };

                    UG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var UA = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "UA");
                if (UA == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "UA",
                        Name = "Ukraine",
                        MobilePrefix = "+380",
                        OrderNumber = 1223
                    };

                    UA = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var AE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "AE");
                if (AE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "AE",
                        Name = "United Arab Emirates",
                        MobilePrefix = "+971",
                        OrderNumber = 1224
                    };

                    AE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var GB = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "GB");
                if (GB == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "GB",
                        Name = "United Kingdom",
                        MobilePrefix = "+44",
                        OrderNumber = 1225
                    };

                    GB = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var US = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "US");
                if (US == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "US",
                        Name = "United States",
                        MobilePrefix = "+1",
                        OrderNumber = 1226
                    };

                    US = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var UM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "UM");
                if (UM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "UM",
                        Name = "United States Minor Outlying Islands",
                        MobilePrefix = "+1",
                        OrderNumber = 1227
                    };

                    UM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var UY = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "UY");
                if (UY == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "UY",
                        Name = "Uruguay",
                        MobilePrefix = "+598",
                        OrderNumber = 1228
                    };

                    UY = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var UZ = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "UZ");
                if (UZ == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "UZ",
                        Name = "Uzbekistan",
                        MobilePrefix = "+998",
                        OrderNumber = 1229
                    };

                    UZ = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VU = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VU");
                if (VU == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VU",
                        Name = "Vanuatu",
                        MobilePrefix = "+678",
                        OrderNumber = 1230
                    };

                    VU = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VE");
                if (VE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VE",
                        Name = "Venezuela",
                        MobilePrefix = "+58",
                        OrderNumber = 1231
                    };

                    VE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VN = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VN");
                if (VN == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VN",
                        Name = "Viet Nam",
                        MobilePrefix = "+84",
                        OrderNumber = 1232
                    };

                    VN = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VG = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VG");
                if (VG == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VG",
                        Name = "Virgin Islands, British",
                        MobilePrefix = "+1284",
                        OrderNumber = 1233
                    };

                    VG = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var VI = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "VI");
                if (VI == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "VI",
                        Name = "Virgin Islands, U.s.",
                        MobilePrefix = "+1340",
                        OrderNumber = 1234
                    };

                    VI = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var WF = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "WF");
                if (WF == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "WF",
                        Name = "Wallis and Futuna",
                        MobilePrefix = "+681",
                        OrderNumber = 1235
                    };

                    WF = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var EH = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "EH");
                if (EH == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "EH",
                        Name = "Western Sahara",
                        MobilePrefix = "+212",
                        OrderNumber = 1236
                    };

                    EH = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var YE = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "YE");
                if (YE == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "YE",
                        Name = "Yemen",
                        MobilePrefix = "+967",
                        OrderNumber = 1237
                    };

                    YE = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ZM = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ZM");
                if (ZM == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ZM",
                        Name = "Zambia",
                        MobilePrefix = "+260",
                        OrderNumber = 1238
                    };

                    ZM = await _countryRepository.InsertAsync(country, autoSave: true);

                }

                var ZW = countries.IgnoreQueryFilters().FirstOrDefault(x => x.Code == "ZW");
                if (ZW == null)
                {
                    var country = new Country
                    {

                        IsActive = true,
                        Code = "ZW",
                        Name = "Zimbabwe",
                        MobilePrefix = "+263",
                        OrderNumber = 1239
                    };

                    ZW = await _countryRepository.InsertAsync(country, autoSave: true);

                }

            }
        }
    }
}

*/