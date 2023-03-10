using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Types;

public class TypeDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Type, int> _typeRepository;

    public TypeDataSeederContributor(IRepository<Type, int> typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _typeRepository.GetCountAsync() <= 0)
        {
            await _typeRepository.InsertAsync(new Type(2001, 1001, true, "Leggings", "Leggings", "LEG", 1003, 1.25, 15, 3, 1004, 12, 16, 7, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1006, true, "Active Tank", "Active Tank", "ATK", 1004, 1, 10, 3, 1007, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1063, true, "Capri Leggings", "Capri Leggings", "LEG1", 1008, 1, 15, 2.25, 1004, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1065, true, "Active Top", "Active Top", "ATP", 1009, 1, 10, 3, 1007, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1066, true, "Active Tshirt", "Active Tshirt", "ATS", 1010, 1, 2, 0.8, 1008, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1324, true, "Active Skort", "Active Skort", "AST", 1010, 1.2, 2, 0.8, 1008, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1330, true, "Active Bra Tank", "Active Bra Tank", "ABT", 1003, 2, 10, 1.5, 1007, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1327, true, "Active Body Suit", "Active Body Suit", "ABS", 1010, 1.2, 5, 0.75, 1002, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2002, 1008, true, "Sweat Hoodie", "Sweat Hoodie", "HOD", 1001, 1.7, 15, 3, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1009, true, "Sweatshirt", "Sweatshirt", "SSH", 1008, 1.5, 15, 3, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1010, true, "Sweat Jogger", "Sweat Jogger", "JGR", 1002, 1.5, 15, 3, 1004, 15, 24, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2002, 1012, true, "Sweat Dress", "Sweat Dress", "SDR", 1005, 1.8, 5, 1.75, 1002, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1013, true, "Sweat Skirt", "Sweat Skirt", "SKT", 1007, 1.2, 3, 0.6, 1006, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1014, true, "Sweat Coat", "Sweat Coat", "SCT", 1004, 2.5, 10, 1, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1015, true, "Sweat Cardigan", "Sweat Cardigan", "SCG", 1003, 2.5, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1016, true, "Sweat Jacket", "Sweat Jacket", "SJT", 1006, 1.9, 15, 1, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1067, true, "Sweat Vest", "Sweat Vest", "SVT", 1010, 1.2, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);


            await _typeRepository.InsertAsync(new Type(2003, 1017, true, "Jersey Tank", "Jersey Tank", "JTK", 1005, 1, 10, 1, 1007, 12, 16, 7, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1018, true, "Jersey Tshirt", "Jersey Tshirt", "JTS", 1008, 1, 2, 0.6, 1008, 12, 16, 7, 8, 5), autoSave: true);
            //await _typeRepository.InsertAsync(new Type(2003, 1019, true, "Jersey Jumpsuit", "Jersey Jumpsuit", "JJS", 1004, 0, 0, 0), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1020, true, "Jersey Dress", "Jersey Dress", "JDR", 1001, 1.5, 5, 0.75, 1002, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1021, true, "Jersey Skirt", "Jersey Skirt", "JSK", 1007, 1.2, 3, 0.6, 1006, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1022, true, "Jersey Hoodie", "Jersey Hoodie", "JHO", 1002, 1.5, 15, 1.5, 1003, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1023, true, "Jersey Jogger", "Jersey Jogger", "JJG", 1003, 1.7, 15, 1.5, 1004, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1328, true, "Jersey Bra Tank", "Jersey Bra Tank", "JBT", 1003, 1.2, 10, 0.5, 1007, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2004, 1025, true, "Lounge Pants", "Lounge Pants", "LPA", 1005, 2.39, 10, 1, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1026, true, "Lounge Shirt", "Lounge Shirt", "LST", 1006, 0.6, 10, 0.5, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1027, true, "Lounge Tank", "Lounge Tank", "LTN", 1010, 0.35, 10, 0.5, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1028, true, "Lounge Bra", "Lounge Bra", "LBR", 1002, 0.3, 10, 1, 1009, 16, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2004, 1029, true, "Lounge Dress", "Lounge Dress", "LDR", 1004, 0.6, 10, 0.5, 1009, 16, 16, 24, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1030, true, "Lounge Skirt", "Lounge Skirt", "LSK", 1008, 0.65, 10, 1, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1031, true, "Lounge Shorts", "Lounge Shorts", "LSH", 1007, 0.3, 10, 0.5, 1009, 16, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2004, 1032, true, "Lounge Cardigan", "Lounge Cardigan", "CAR", 1003, 2.73, 10, 0.67, 1009, 16, 16, 24, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1325, true, "Lounge Cardigan Wrap", "Lounge Cardigan Wrap", "LCW", 1003, 1.3, 10, 0.67, 1009, 16, 16, 24, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1033, true, "Lounge Sweater", "Lounge Sweater", "SWE", 1009, 2.2, 10, 0.75, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1060, true, "Lounge Top", "Lounge Top", "LTP", 1010, 0.6, 10, 0.5, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1061, true, "Lounge Hoodie", "Lounge Hoodie", "LHO", 1011, 1.95, 10, 0.75, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1062, true, "Lounge Jumpsuit", "Lounge Jumpsuit", "LJS", 1012, 1.43, 10, 0.5, 1009, 16, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1068, true, "Lounge Jacket", "Lounge Jacket", "LJK", 1015, 1.89, 10, 0.67, 1009, 16, 16, 24, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2004, 1035, true, "Lounge Scarf", "Lounge Scarf", "LSF", 1011, 0.12, 10, 0.2, 1009, 16, 16, 24, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2004, 1323, true, "Lounge Headband", "Lounge Headband", "LHB", 1011, 0.09, 10, 0.3, 1009, 16, 16, 24, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2005, 1036, true, "Mesh Tank", "Mesh Tank", "MTK", 1001, 1.1, 10, 1, 1007, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2005, 1037, true, "Mesh Tshirt", "Mesh Tshirt", "MTS", 1002, 1.1, 2, 0.6, 1008, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2005, 1055, true, "Mesh Running Shorts", "Mesh Running Shorts", "MSH", 1003, 0.8, 15, 0.45, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2005, 1059, true, "Mesh Top", "Mesh Top", "MTP", 1004, 1, 10, 1, 1007, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2005, 1326, true, "Mesh Skort", "Mesh Skort", "MSK", 1010, 1.2, 2, 0.8, 1008, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2005, 1329, true, "Mesh Bra Tank", "Mesh Bra Tank", "MBT", 1003, 1, 10, 0.5, 1007, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2006, 1038, true, "WindBreaker Jacket", "Windbreaker Jacket", "WBJ", 1001, 1, 10, 2, 1010, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2006, 1039, true, "Windbreaker Running Shorts", "Windbreaker Running Shorts", "WSH", 1003, 1.2, 15, 1.05, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2006, 1040, true, "WindBreaker Pants", "WindBreaker Pants", "WPA", 1002, 1.8, 15, 2.25, 1004, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2006, 1057, true, "WindBreaker Shorts", "WindBreaker Shorts", "WSHO1", 1004, 1.1, 15, 1.05, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2006, 1058, true, "WindBreaker Hoodie", "WindBreaker Hoodie", "WSHO", 1005, 2.8, 15, 1.5, 1003, 12, 16, 7, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2001, 1041, true, "2\" Micro Shorts", "2\" Micro Shorts", "SHO2", 1008, 0.5, 15, 0.75, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1042, true, "4\" Shorts", "4\" Shorts", "SHO4", 1009, 0.65, 15, 0.75, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1043, true, "7\" Biker Shorts", "7\" Biker Shorts", "BSH7", 1010, 0.8, 15, 0.75, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1064, true, "10\" Biker Shorts", "10\" Biker Shorts", "BSH10", 1011, 1, 15, 0.75, 1005, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2001, 1044, true, "Sports Bra Base 1", "Sports Bra Base 1", "BRA1", 1011, 0.5, 25, 8.34, 1001, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1045, true, "Sports Bra Base 2", "Sports Bra Base 2", "BRA2", 1012, 0.7, 25, 8.33, 1001, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1046, true, "Sports Bra Base 3", "Sports Bra Base 3", "BRA3", 1013, 0.8, 25, 8.33, 1001, 12, 16, 7, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2001, 1047, true, "Active Dress", "Active Dress", "ADR", 1014, 2, 5, 1, 1002, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2001, 1048, true, "Active Skirt", "Active Skirt", "ASK", 1015, 1.2, 3, 1.2, 1006, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2002, 1049, true, "3\" Sweatshorts", "3\" Sweatshorts", "SSR3", 1010, 0.6, 15, 1.05, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1050, true, "5\" Sweatshorts", "5\" Sweatshorts", "SSR5", 1011, 0.8, 15, 1.05, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2002, 1051, true, "7\" Sweatshorts", "7\" Sweatshorts", "SSR7", 1012, 1, 15, 1.05, 1005, 15, 24, 11, 8, 5), autoSave: true);


            await _typeRepository.InsertAsync(new Type(2003, 1052, true, "3\" Jersey Shorts", "3\" Jersey Shorts", "JSR3", 1009, 0.5, 15, 0.6, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1053, true, "5\" Jersey Shorts", "5\" Jersey Shorts", "JSR5", 1010, 0.7, 15, 0.6, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1054, true, "7\" Jersey Shorts", "7\" Jersey Shorts", "JSR7", 1011, 0.9, 15, 0.6, 1005, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2003, 1056, true, "Jersey Top", "Jersey Top", "JTP", 1012, 1, 10, 1, 1007, 12, 16, 11, 8, 5), autoSave: true);


            await _typeRepository.InsertAsync(new Type(2012, 1101, true, "Polar Fleece Hoodie", "Polar Fleece Hoodie", "PFH", 1001, 1.7, 15, 1.5, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1102, true, "Polar Fleece Shirt", "Polar Fleece Shirt", "PFS", 1002, 1.5, 15, 1.5, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1103, true, "Polar Fleece Jogger", "Polar Fleece Jogger", "PFJ", 1003, 1.5, 15, 1.5, 1004, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1104, true, "3\" Polar Fleece Shorts", "3\" Polar Fleece Shorts", "PFS3", 1004, 0.6, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1105, true, "5\" Polar Fleece Shorts", "5\" Polar Fleece Shorts", "PFS5", 1005, 0.8, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1106, true, "7\" Polar Fleece Shorts", "7\" Polar Fleece Shorts", "PFS7", 1006, 1, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2012, 1107, true, "Polar Fleece Dress", "Polar Fleece Dress", "PFD", 1007, 1.8, 5, 0.75, 1002, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1108, true, "Polar Fleece Skirt", "Polar Fleece Skirt", "PFSK", 1008, 1.2, 3, 0.3, 1006, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1109, true, "Polar Fleece Coat", "Polar Fleece Coat", "PFC", 1009, 2.5, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1110, true, "Polar Fleece Cardigan", "3Polar Fleece Cardigan", "PFCD", 1010, 2.5, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1111, true, "Polar Fleece Jacket", "Polar Fleece Jacket", "PFJ", 1011, 1.9, 10, 1, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2012, 1112, true, "Polar Fleece Vest", "Polar Fleece Vest", "PFV", 1012, 1.2, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);


            await _typeRepository.InsertAsync(new Type(2011, 1201, true, "Tea Bag Mesh Top", "Tea Bag Mesh Top", "TMTP", 1001, 1, 0, 0, null, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2011, 1202, true, "Tea Bag Mesh Tank", "Tea Bag Mesh Tank", "TMTK", 1002, 1.1, 0, 0, null, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2011, 1203, true, "Tea Bag Mesh Tshirt", "Tea Bag Mesh Tshirt", "TMTS", 1003, 1.1, 0, 0, null, 12, 16, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2011, 1204, true, "Tea Bag Mesh Running Shorts", "Tea Bag Mesh Running Shorts", "TMSH", 1004, 0.8, 0, 0, null, 12, 16, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2009, 1311, true, "French Terry Hoodie", "French Terry Hoodie", "FTH", 1001, 1.7, 15, 1.5, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1312, true, "French Terry Shirt", "French Terry Shirt", "FTS", 1002, 1.5, 15, 1.5, 1003, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1313, true, "French Terry Jogger", "French Terry Jogger", "FTJ", 1003, 1.5, 15, 1.5, 1004, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1314, true, "3\" French Terry Shorts", "3\" French Terry Shorts", "FTS3", 1004, 0.6, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1315, true, "5\" French Terry Shorts", "5\" French Terry Shorts", "FTS5", 1005, 0.8, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1316, true, "7\" French Terry Shorts", "7\" French Terry Shorts", "FTS7", 1006, 1, 15, 0.75, 1005, 15, 24, 11, 8, 5), autoSave: true);

            await _typeRepository.InsertAsync(new Type(2009, 1317, true, "French Terry Dress", "French Terry Dress", "FTD", 1007, 1.8, 5, 0.75, 1002, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1318, true, "French Terry Skirt", "French Terry Skirt", "FTSK", 1008, 1.2, 3, 0.3, 1006, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1319, true, "French Terry Coat", "French Terry Coat", "FTC", 1009, 2.5, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1320, true, "French Terry Cardigan", "French Terry Cardigan", "FTCD", 1010, 2.5, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1321, true, "French Terry Jacket", "French Terry Jacket", "FTJT", 1011, 1.9, 10, 1, 1010, 15, 24, 11, 8, 5), autoSave: true);
            await _typeRepository.InsertAsync(new Type(2009, 1322, true, "French Terry Vest", "French Terry Vest", "FTV", 1012, 1.2, 10, 0.5, 1010, 15, 24, 11, 8, 5), autoSave: true);
        }
    }
}