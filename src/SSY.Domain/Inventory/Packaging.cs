

using System;
using System.Collections.Generic;
using SSY.Inventory.CareInstructionTypes;
using SSY.Inventory.ProductAssignments;
using SSY.Inventory.UnitOfMeasurements;

namespace SSY.Inventory
{
    /// <summary>
    /// Packaging NEED REFACTOR
    /// </summary>
    [Table("AppPackagings")]
    public class Packaging : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        #region Inventory

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double TotalCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? MinimumStockLevel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? IncomingCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? ReservedCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? AvailableCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? UsedCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? OnHandCount { get; set; }

        [Required]
        public int UnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(UnitOfMeasurementId))]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        [Required]
        public Guid MediaFileId { get; set; }
        [ForeignKey(nameof(MediaFileId))]
        public MediaFile MediaFile { get; set; }

        #endregion

        #region Miscellanous
        [Required]
        public int? CareInstructionTypeId { get; set; }
        [ForeignKey(nameof(CareInstructionTypeId))]
        public CareInstructionType CareInstructionType { get; set; }

        #endregion

        #region Roll And Location

        public List<Roll> RollsAndLocations { get; set; }

        public void AddRollAndLocation(Roll rollAndLocation)
        {
            RollsAndLocations.Add(rollAndLocation);
        }

        #endregion

        #region Supplier

        [Required]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        #endregion

        #region Purchase Detail

        public Guid? PurchaseDetailId { get; set; }
        [ForeignKey(nameof(PurchaseDetailId))]
        public PurchaseDetail PurchaseDetail { get; set; }

        #endregion

        #region Product Assignments

        public List<ProductAssignment> Assignments { get; set; }

        public void AddProductAssingment(ProductAssignment productAssignment)
        {
            Assignments.Add(productAssignment);
        }

        #endregion

        // Default constructor use by Entity Framework Core don't remove.
        public Packaging()
        {
        }

        public Packaging(double totalCount, double? minimumStockLevel, double? incomingCount, double? reservedCount,
                        double? availableCount, double? usedCount, double? onHandCount)
        {
            TotalCount = totalCount;
            MinimumStockLevel = minimumStockLevel;
            IncomingCount = incomingCount;
            ReservedCount = reservedCount;
            AvailableCount = availableCount;
            UsedCount = usedCount;
            OnHandCount = onHandCount;
        }

    }
}
