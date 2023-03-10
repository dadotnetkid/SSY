/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Colors
{
    public class ColorDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Color, int> _colorRepository;

        public ColorDataSeederContributor(IRepository<Color, int> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _colorRepository.GetCountAsync() <= 0)
            {
                await _colorRepository.InsertAsync(new Color(1001, "White", "White", "#FFFFFF", 1013, "WHI", 10));
                await _colorRepository.InsertAsync(new Color(1002, "Yellow", "Yellow", "#FFFF00", 1014, "YEL", 2));
                await _colorRepository.InsertAsync(new Color(1003, "Orange", "Orange", "#FFA500", 1009, "ORG", 2));
                await _colorRepository.InsertAsync(new Color(1004, "Red", "Red", "#FF0000", 1012, "RED", 2));
                await _colorRepository.InsertAsync(new Color(1005, "Pink", "Pink", "#FFC0CB", 1010, "PNK", 2));
                await _colorRepository.InsertAsync(new Color(1006, "Purple", "Purple", "#800080", 1011, "PRP", 2));
                await _colorRepository.InsertAsync(new Color(1007, "Light Blue", "Light Blue", "#ADD8E6", 1008, "LBL", 4));
                await _colorRepository.InsertAsync(new Color(1008, "Green", "Green", "#00FF00", 1006, "GRE", 2));
                await _colorRepository.InsertAsync(new Color(1009, "Beige", "Beige", "#F5F5DC", 1001, "BEI", 2));
                await _colorRepository.InsertAsync(new Color(1010, "Brown", "Brown", "#964B00", 1003, "BRW", 2));
                await _colorRepository.InsertAsync(new Color(1011, "Grey", "Grey", "#808080", 1007, "GRY", 2));
                await _colorRepository.InsertAsync(new Color(1012, "Black", "Black", "#000000", 1002, "BLK", 60));
                await _colorRepository.InsertAsync(new Color(1013, "Dark Blue", "Dark Blue", "#000080", 1005, "DBl", 4));
                await _colorRepository.InsertAsync(new Color(1014, "Clear", "Clear", "#F4FAFC", 1004, "CLR", 4));
            }
        }
    }
}

*/