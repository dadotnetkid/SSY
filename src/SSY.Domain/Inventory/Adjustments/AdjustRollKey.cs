using System;

namespace SSY.Inventory.Adjustments;

/// <summary>
/// Roll Adjustment
/// </summary>
[Table("AppAdjustRollKeys")]
public class AdjustRollKey : Entity<Guid>
{
    public int TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid AdjustmentId { get; set; }
    [ForeignKey(nameof(AdjustmentId))]
    public Adjustment Adjustment { get; set; }

    public Guid RollId { get; set; }
    [ForeignKey(nameof(RollId))]
    public Roll Roll { get; set; }

    public AdjustRollKey()
    {
    }

    public AdjustRollKey(int tenantid, bool isActive, Guid adjustmentId, Guid rollId)
    {
        TenantId = tenantid;
        IsActive = isActive;
        AdjustmentId = adjustmentId;
        RollId = rollId;
    }
}

