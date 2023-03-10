/*using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SSY.Inventory.Materials.Types
{
    public class TypePanelKeyDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<TypePanelKey, Guid> _typePanelKeyRepository;

        public TypePanelKeyDataSeederContributor(IRepository<TypePanelKey, Guid> typePanelKeyRepository)
        {
            _typePanelKeyRepository = typePanelKeyRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _typePanelKeyRepository.GetCountAsync() <= 0)
            {
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2001, 2001));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2001, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2001, 2011));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2002));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2012));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2006));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2011));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2002, 2009));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2012));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2002));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2006));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2011));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2012, 2009));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2009));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2012));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2002));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2006));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2009, 2011));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2003, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2003, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2003, 2011));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2003, 2006));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2005, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2005, 2011));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2005, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2005, 2006));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2011, 2011));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2011, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2011, 2003));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2011, 2006));

                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2006));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2002));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2012));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2009));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2005));
                await _typePanelKeyRepository.InsertAsync(new TypePanelKey(2006, 2011));
            }
        }
    }
}

*/