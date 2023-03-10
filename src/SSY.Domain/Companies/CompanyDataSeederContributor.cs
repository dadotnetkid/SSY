/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Companies
{
    public class CompanyDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Company, int> _companyRepository;

        public CompanyDataSeederContributor(IRepository<Company, int> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _companyRepository.GetCountAsync() <= 0)
            {
                var ssy = new Company(
                    id: 1000,
                    tenantId: 1,
                    isActive: true,
                    code: "SSY-PH-CLA-00",
                    shortCode: "SSY",
                    name: "SEWSEW YOU LTD",
                    website: "http://sewsewyou.com",
                    address1: "7500 A Bonifacio Ave. cor. J Tinsay St.",
                    address2: "Clark Freeport Zone",
                    country: "PH",
                    city: "Clark Freeport Zone",
                    province: "Pampanga",
                    zipCode: "202310",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(ssy);

                var tht = new Company(
                    id: 1001,
                    tenantId: 1,
                    isActive: true,
                    code: "THT-CN-DON-01",
                    shortCode: "THT",
                    name: "TIEN-HU TRADING (HK) LTD",
                    website: "http://sewsewyou.com",
                    address1: "Tienhu Knitting Co. Ltd. of Dongguan",
                    address2: "Mulun Industrial District",
                    country: "CN",
                    city: "Dongguan",
                    province: "Guangdong",
                    zipCode: "523562",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(tht);

                var ytpi = new Company(
                    id: 1002,
                    tenantId: 1,
                    isActive: true,
                    code: "YTPI-PH-LAP-02",
                    shortCode: "YTPI",
                    name: "YUENTHAI PHILIPPINES INCORPORATED",
                    website: "http://www.yuenthai.com",
                    address1: "3rd Avenue, 5th Street,",
                    address2: "Mactan Economic Zone 1,",
                    country: "PH",
                    city: "Lapu Lapu City",
                    province: "Cebu",
                    zipCode: "6015",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(ytpi);

                var lnt = new Company(
                    id: 1003,
                    tenantId: 1,
                    isActive: true,
                    code: "LNT-PH-CLA-03",
                    shortCode: "LNT",
                    name: "L & T INTERNATIONAL GROUP PHILIPPINES INCORPORATED",
                    website: "https://www2.luenthai.com",
                    address1: "7500 A Bonifacio Ave. cor. J Tinsay St.",
                    address2: "Clark Freeport Zone",
                    country: "PH",
                    city: "Clark Freeport Zone",
                    province: "Pampanga",
                    zipCode: "2023",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: true);

                await _companyRepository.InsertAsync(lnt);

                var yty = new Company(
                    id: 1004,
                    tenantId: 1,
                    isActive: true,
                    code: "YTY-PH-LAP-04",
                    shortCode: "YTY",
                    name: "YTY DIGITAL PRINT CORP",
                    website: null,
                    address1: "Factory 2 – 3rd Avenue 5th St. MEZ 1",
                    address2: null,
                    country: "PH",
                    city: "Lapu-Lapu City",
                    province: "Cebu",
                    zipCode: "6016",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(yty);

                var sfpc = new Company(
                    id: 1005,
                    tenantId: 1,
                    isActive: true,
                    code: "SFPC-HK-KOW-05",
                    shortCode: "SFPC",
                    name: "SING FUNG PIECE GOODS CO LTD",
                    website: "http://biznetvigator.com",
                    address1: "G/F. 98B, Ki Lung Street, Shamshuipo",
                    address2: null,
                    country: "HK",
                    city: "Kowloon",
                    province: "Kowloon",
                    zipCode: "0",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(sfpc);

                var ykk = new Company(
                    id: 1006,
                    tenantId: 1,
                    isActive: true,
                    code: "YKK-PH-BAT-06",
                    shortCode: "YKK",
                    name: "YKK PH",
                    website: "https://www.ykk.com.ph/",
                    address1: "Sto Tomas Batangas",
                    address2: null,
                    country: "PH",
                    city: "Batangas",
                    province: "Batangas",
                    zipCode: "4234",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(ykk);

                var sttt = new Company(
                    id: 1007,
                    tenantId: 1,
                    isActive: true,
                    code: "STTT-CN-MIN-07",
                    shortCode: "STTT",
                    name: "SHANGHAI TREND TEXTILE TECHNOLOGY CO LTD",
                    website: null,
                    address1: "Room 701, Building 1, No. 2899 South Lianhua Road,",
                    address2: null,
                    country: "CN",
                    city: "Minhang District",
                    province: "Shanhai",
                    zipCode: "201109",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(sttt);

                var wdw = new Company(
                    id: 1008,
                    tenantId: 1,
                    isActive: true,
                    code: "WDW-CN-HUA-08",
                    shortCode: "WDW",
                    name: "WILSON DYEING & WEAVING (HUA DU) LTD",
                    website: null,
                    address1: "The Overseas Chinese Scientific and Technological Industrict Paik",
                    address2: "Hua Shan Town",
                    country: "CN",
                    city: "Huadu District",
                    province: "Guangdong ",
                    zipCode: "510880",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(wdw);

                var msl = new Company(
                    id: 1009,
                    tenantId: 1,
                    isActive: true,
                    code: "MSL-HK-KOW-09",
                    shortCode: "MSL",
                    name: "MIRACLE SOURCING LTD",
                    website: "http://www.miraclesourcinglimited.com",
                    address1: "Unit 5, 2/F, Block B, Hoplite Industrial Centre",
                    address2: "NO. 3-5 WANG TAI ROAD, ",
                    country: "HK",
                    city: "Kowloon Bay",
                    province: "Kowloon Bay",
                    zipCode: "0",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(msl);

                var fsk = new Company(
                    id: 1010,
                    tenantId: 1,
                    isActive: true,
                    code: "FSK-CN-FOS-10",
                    shortCode: "FSK",
                    name: "FOSHAN SHUNDE KAIXIN KNITTING CO LTD",
                    website: null,
                    address1: "The Beihe Synthesls Industry Developing Zone, Xingtan, Shunde, Foshan",
                    address2: "NO. 3-5 WANG TAI ROAD",
                    country: "CN",
                    city: "Foshan",
                    province: "Guangdong ",
                    zipCode: "528303",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(fsk);

                var skcl = new Company(
                    id: 1011,
                    tenantId: 1,
                    isActive: true,
                    code: "SKCL-CN-SHEN-11",
                    shortCode: "SKCL",
                    name: "SUNRISE (SHENGZHOU) KNITS CO LTD",
                    website: "http://smart-shirts.com.cn/",
                    address1: "No. 2 Wuhe West Road ,Santang town",
                    address2: "Economic Developing Zone",
                    country: "CN",
                    city: "Shengzhou",
                    province: "Zhejiang",
                    zipCode: "312400",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(skcl);

                var gjm = new Company(
                    id: 1012,
                    tenantId: 1,
                    isActive: true,
                    code: "GJM-HK-KOW-12",
                    shortCode: "GJM",
                    name: "GJM",
                    website: null,
                    address1: "Luen Thai International Group Limited",
                    address2: "Rooms 01-05 10/F  nanyang Plaza, 57 Hung To Road Kwuntong ",
                    country: "HK",
                    city: "Kowloon",
                    province: "Kowloon",
                    zipCode: "0",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(gjm);

                var wbsg = new Company(
                    id: 1013,
                    tenantId: 1,
                    isActive: true,
                    code: "WBSG-CN-ZHE-13",
                    shortCode: "WBSG",
                    name: "WENZHOU BONVAN STATIOENERY & GIFTS CO LTD",
                    website: "https://cheapens.en.alibaba.com/",
                    address1: "Zhejiang, China",
                    address2: null,
                    country: "CN",
                    city: "Zhejiang",
                    province: "Zhejiang",
                    zipCode: "31000",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(wbsg);

                var gzypp = new Company(
                    id: 1014,
                    tenantId: 1,
                    isActive: true,
                    code: "GZYPP-CN-ZEN-14",
                    shortCode: "GZYPP",
                    name: "GUANGZHOU ZENGCHENG YIXUAN PACKING PRODUCT FACTORY",
                    website: "https://gzzcyixuan.en.alibaba.com/",
                    address1: "4F, Building 4, Juxin Industrial Park, Shapu Yinsha Industrial Zone, Xintang Town, Zengcheng District, Guangzhou, China",
                    address2: null,
                    country: "CN",
                    city: "Zengceng District",
                    province: "Guangzhou",
                    zipCode: "511300",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(gzypp);

                var hskfl = new Company(
                    id: 1015,
                    tenantId: 1,
                    isActive: true,
                    code: "HSKFL-HK-KWA-15",
                    shortCode: "HSKFL",
                    name: "HOI SHUN KNITTING FACTORY LIMITED",
                    website: null,
                    address1: "Block A, 16/F., Wing Cheung Industrial Building, 58-70 Kwai Cheong Road, Kwai Chung, N.T., Hong Kong",
                    address2: null,
                    country: "HK",
                    city: "Kwai Chung",
                    province: "New Territories",
                    zipCode: "0",
                    bankName: "DBS BANK (HONGKONG) LIMITED",
                    accountNumber: "016-478-780201770",
                    accountName: "Hoi Shun Knitting Factory Limited",
                    swift: "DHBKHKHH",
                    address: "Block A, 16/F., Wing Cheung Industrial Building, 58-70 Kwai Cheong Road, Kwai Chung, N.T., Hong Kong",
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(hskfl);

                var wscg = new Company(
                    id: 1016,
                    tenantId: 1,
                    isActive: true,
                    code: "WSCG-CN-ZHE-16",
                    shortCode: "WSCG",
                    name: "WENZHOU SHENZHOU CRAFT GIFT CO LTD",
                    website: "https://ashenzhou.en.alibaba.com/",
                    address1: "No.245 GonHou Road",
                    address2: "Longgang Town",
                    country: "CN",
                    city: "Zhejiang",
                    province: "Zhejiang",
                    zipCode: "325000",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: false);

                await _companyRepository.InsertAsync(wscg);

                var skc = new Company(
                    id: 1017,
                    tenantId: 1,
                    isActive: true,
                    code: "SKC-PH-CLA-17",
                    shortCode: "SKC",
                    name: "DONGGUAN TOMWELL GARMENT COMPANY LTD",
                    website: "https://www2.luenthai.com",
                    address1: "Jin Feng Huang Development District",
                    address2: "Tang Li, Feng Gang Town,",
                    country: "CN",
                    city: "DONGGUAN",
                    province: "GUANGDONG",
                    zipCode: "523000",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: true);

                await _companyRepository.InsertAsync(skc);

                var cmb = new Company(
                    id: 1018,
                    tenantId: 1,
                    isActive: true,
                    code: "CMB-KH-KHA-18",
                    shortCode: "CMB",
                    name: "YUENTHAI CAMBODIA (SUNTEX PTE LTD)",
                    website: "https://www2.luenthai.com/",
                    address1: "#8, Street Choam Chao Sangkat Choam Cha",
                    address2: "Khan Porsenchey, Phnom Penh, Cambodia",
                    country: "KH",
                    city: "Khan Porsenchey",
                    province: "Phnom Penh",
                    zipCode: "",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: true);

                await _companyRepository.InsertAsync(cmb);

                var tms = new Company(
                    id: 1019,
                    tenantId: 1,
                    isActive: true,
                    code: "TMS-KH-DAN-19",
                    shortCode: "TMS",
                    name: "TMS FASHION (HK) LTD",
                    website: "https://www.tmsfashion.com/",
                    address1: "No 8 & 9, Street Choam Chao, Sangkat Choam Chao, Khan",
                    address2: "Dangkor, Phnom Penh, Cambodia",
                    country: "KH",
                    city: "Dangkor",
                    province: "Phnom Penh",
                    zipCode: "",
                    bankName: null,
                    accountNumber: null,
                    accountName: null,
                    swift: null,
                    address: null,
                    isExcessSupplier: true);

                await _companyRepository.InsertAsync(tms);

            }
        }
    }
}*/