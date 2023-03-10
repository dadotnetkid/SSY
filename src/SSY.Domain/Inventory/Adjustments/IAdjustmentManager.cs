using System.Threading.Tasks;

namespace SSY.Inventory.Adjustments
{
    public interface IAdjustmentManager : IDomainService
    {
        Task AdjustRollAsync(Adjustment adjustment, Roll roll);
        Task DisposeRollAsync(Adjustment adjustment, Roll roll);
        Task AdjustSubMaterialAsync(Adjustment adjustment, Roll roll);
        Task DisposeSubMaterialAsync(Adjustment adjustment, Roll roll);
    }
}

