using System.Threading.Tasks;

namespace SSY.Inventory.Materials
{
    public interface IMaterialManager : IDomainService
    {
        Task CalculateActualCountAsync(Material material);
        Task CalculateAvailableCountAsync(Material material);
    }
}
