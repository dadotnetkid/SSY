/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Materials.Types
{
    public class PanelDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Panel, int> _panelRepository;

        public PanelDataSeederContributor(IRepository<Panel, int> panelRepository)
        {
            _panelRepository = panelRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _panelRepository.GetCountAsync() <= 0)
            {
                await _panelRepository.InsertAsync(new Panel(2001, "Activewear", "Activewear", 1001));
                await _panelRepository.InsertAsync(new Panel(2002, "Sweats", "Sweats", 1006));
                await _panelRepository.InsertAsync(new Panel(2003, "Jersey", "Jersey", 1002));
                await _panelRepository.InsertAsync(new Panel(2004, "Knitwear", "Knitwear", 1004));
                await _panelRepository.InsertAsync(new Panel(2005, "Mesh", "Mesh", 1005));
                await _panelRepository.InsertAsync(new Panel(2006, "Windbreaker", "Windbreaker", 1008));
                await _panelRepository.InsertAsync(new Panel(2007, "Sweats Rib", "Sweats Rib", 1007));
                await _panelRepository.InsertAsync(new Panel(2008, "Jersey Rib", "Jersey Rib", 1003));
                await _panelRepository.InsertAsync(new Panel(2009, "French Terry", "French Terry", 1009));
                await _panelRepository.InsertAsync(new Panel(2010, "French Terry Rib", "French Terry Rib", 1010));
                await _panelRepository.InsertAsync(new Panel(2011, "Tea Bag Mesh", "Tea Bag Mesh", 1011));
                await _panelRepository.InsertAsync(new Panel(2012, "Polar Fleece", "Polar Fleece", 1012));
                await _panelRepository.InsertAsync(new Panel(2013, "Polar Fleece Rib", "Polar Fleece Rib", 1013));
            }
        }
    }

}*/