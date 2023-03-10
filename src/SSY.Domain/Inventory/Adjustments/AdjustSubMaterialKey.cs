using System;

namespace SSY.Inventory.Adjustments
{
    /// <summary>
    /// SubMaterial Adjustment
    /// </summary>
    [Table("AppAdjustSubMaterialKeys")]
    public class AdjustSubMaterialKey : Entity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public Guid AdjustmentId { get; set; }
        [ForeignKey(nameof(AdjustmentId))]
        public Adjustment Adjustment { get; set; }

        public Guid SubMaterialId { get; set; }
        [ForeignKey(nameof(SubMaterialId))]
        public SubMaterial SubMaterial { get; set; }

        public AdjustSubMaterialKey()
        {
        }

        public AdjustSubMaterialKey(int tenantid, bool isActive, Guid adjustmentId, Guid subMaterialId)
        {
            TenantId = tenantid;
            IsActive = isActive;
            AdjustmentId = adjustmentId;
            SubMaterialId = subMaterialId;
        }
    }
}

