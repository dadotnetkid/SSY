/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Materials.Types
{
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
                await _typeRepository.InsertAsync(new Type(1001, "Greige Activewear", "Greige Activewear", 1001, "GAW", 1, 0, 1001));
                await _typeRepository.InsertAsync(new Type(1002, "Greige Jersey", "Greige Jersey", 1002, "GJS", 1, 0, 1001));
                await _typeRepository.InsertAsync(new Type(1003, "Greige Windbreaker", "Greige Windbreaker", 1004, "GWB", 1, 0, 1001));
                await _typeRepository.InsertAsync(new Type(1004, "Greige Mesh", "Greige Mesh", 1003, "GMS", 1, 0, 1001));

                await _typeRepository.InsertAsync(new Type(2001, "Activewear", "Activewear", 1001, "ATW", 2, 60, 1001));
                await _typeRepository.InsertAsync(new Type(2002, "Sweats", "Sweats", 1006, "SWT", 2, 10, 1001));
                await _typeRepository.InsertAsync(new Type(2003, "Jersey", "Jersey", 1002, "JRY", 2, 10, 1001));
                await _typeRepository.InsertAsync(new Type(2005, "Mesh", "Mesh", 1005, "MES", 2, 5, 1));
                await _typeRepository.InsertAsync(new Type(2006, "Windbreaker", "Windbreaker", 1008, "WBR", 2, 5, 1));
                await _typeRepository.InsertAsync(new Type(2007, "Sweats Rib", "Sweats Rib", 1007, "SWR", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2008, "Jersey Rib", "Jersey Rib", 1003, "JYR", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2009, "French Terry", "French Terry", 1009, "FTY", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2010, "French Terry Rib", "French Terry Rib", 1010, "FTR", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2011, "Tea Bag Mesh", "Tea Bag Mesh", 1011, "TBM", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2012, "Polar Fleece", "Polar Fleece", 1012, "PFL", 2, 0, 1001));
                await _typeRepository.InsertAsync(new Type(2013, "Polar Fleece Rib", "Polar Fleece Rib", 1013, "PFLR", 2, 0, 1001));

                await _typeRepository.InsertAsync(new Type(3001, "Zipper", "Zipper", 1016, "ZPR", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3002, "Bra Adjuster Ring/Slider Set", "Bra Adjuster Ring/Slider Set", 1002, "BAR", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3003, "Bra Pads", "Bra Pads", 1003, "BPS", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3004, "Elasticband", "Elasticband", 1008, "EBD", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3005, "Drawcord", "Drawcord", 1006, "DRC", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3006, "Lace", "Lace", 1009, "LAC", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3007, "Ribbon Tape", "Ribbon Tape", 1010, "RTP", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3008, "Binding Tape", "Binding Tape", 1001, "BTP", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3009, "Elastic Tape", "Elastic Tape", 1007, "ELT", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3010, "Toggle", "Toggle", 1013, "TGL", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3011, "Tie Cord", "Tie Cord", 1012, "TCD", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3012, "Velcro Female", "Velcro Female", 1014, "VCF", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3013, "Velcro Male", "Velcro Male", 1015, "VCM", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3014, "Carelabel/Sizelabel", "Carelabel/Sizelabel", 1004, "CAL", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3015, "Content Label", "Content Label", 1005, "CNL", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3016, "Thread", "Thread", 1011, "THR", 3, 0, 1001));
                await _typeRepository.InsertAsync(new Type(3017, "Interlining", "Interlining", 1012, "ITL", 3, 0, 1001));

                await _typeRepository.InsertAsync(new Type(4001, "Hang Tags", "Hang Tags", 1004, "HTG", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4002, "Thank you Card", "Thank you Card", 1008, "TYC", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4003, "Ziplock", "Ziplock", 1010, "ZPL", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4004, "Flyer", "Flyer", 1003, "FLR", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4005, "Boxes", "Boxes", 1001, "BOX", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4006, "Canvass Bag", "Canvass Bag", 1002, "CVB", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4007, "Tissue", "Tissue", 1009, "TSS", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4008, "Stickers", "Stickers", 1006, "STK", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4009, "Strings", "Strings", 1007, "STR", 4, 0, 1001));
                await _typeRepository.InsertAsync(new Type(4010, "Pin", "Pin", 1005, "PIN", 4, 0, 1001));

                await _typeRepository.InsertAsync(new Type(5001, "Knitwear", "Knitwear", 1001, "KTW", 5, 10, 2));

                await _typeRepository.InsertAsync(new Type(99001, "Logo Branding (Inside)", "Logo Branding (Inside)", 1001, "LBI", 99, 0, 1001));
                await _typeRepository.InsertAsync(new Type(99002, "Logo Branding (Outside)", "Logo Branding (Outside)", 1002, "LBO", 99, 0, 1001));
            }
        }

    }
}*/