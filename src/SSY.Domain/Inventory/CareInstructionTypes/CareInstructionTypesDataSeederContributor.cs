/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.CareInstructionTypes
{
    public class CareInstructionTypesDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CareInstructionType, int> _careInstructionTypeRepository;

        public CareInstructionTypesDataSeederContributor(IRepository<CareInstructionType, int> careInstructionTypeRepository)
        {
            _careInstructionTypeRepository = careInstructionTypeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _careInstructionTypeRepository.GetCountAsync() <= 0)
            {
                await _careInstructionTypeRepository.InsertAsync(new CareInstructionType(
                id: 1001,
                label: "Activewear/Sweats",
                value: "Wash separately\nBefore you wear\nMachine wash cold\nwith like colors\nDo not bleach\nDo not use softeners\nLine Dry\nDo not Iron\nDo not dry clean",
                orderNumber: 1001), autoSave: true);

                await _careInstructionTypeRepository.InsertAsync(new CareInstructionType(
                    id: 1002,
                    label: "Knitted Cotton/Combed Cotton",
                    value: "Machine Wash Cold\nGentle Cycle\nOnly Non-Chlorine Bleach When Needed\nLay Flat To Dry\nWASH INSIDE WASHING BAG\nCool Iron if needed\nDry Clean",
                    orderNumber: 1002), autoSave: true);

                await _careInstructionTypeRepository.InsertAsync(new CareInstructionType(
                    id: 1003,
                    label: "Knitted Cotton Wool/Cashmere/Merino Wool",
                    value: "Hand Wash Cold\nDo not Bleach\nLay flat to dry\nCool Iron If Needed On Reverse Side\nDry Clean",
                    orderNumber: 1003), autoSave: true);
            }
        }
    }

}*/