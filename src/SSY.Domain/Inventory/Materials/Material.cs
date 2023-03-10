using System;
using System.Collections.Generic;
using SSY.Inventory.CareInstructionTypes;
using SSY.Inventory.Categories;
using SSY.Inventory.Colors;
using SSY.Inventory.UnitOfMeasurements;
using SSY.Inventory.WeightUnits;

namespace SSY.Inventory.Materials
{
    /// <summary>
    /// Material - Gregige / Fabric
    /// </summary>
    [Index(propertyNames: new[] { nameof(ItemCode), nameof(ColorCode) }, IsUnique = true)]
    [Table("AppMaterials")]
    public class Material : FullAuditedAggregateRoot<Guid>
    {
        // Default constructor use by Entity Framework Core don't remove.
        public Material()
        {
        }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        #region Accountability
        /// <summary>
        /// Accountability ForeignKey
        /// </summary>
        public Guid? AccountabilityId { get; set; }
        [ForeignKey(nameof(AccountabilityId))]
        public Accountability Accountability { get; set; }

        #endregion

        #region Overview and Description

        /// <summary>
        /// Uneditable field
        /// ShortCode + Item code + Color code + Excess/New + Material type short code + Unique number (TotalCount+1)
        /// Example: YTI-7526079-095A-E-GAW-001
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Product Assignments
        /// </summary>
        public string AssignmentIds { get; set; }

        #region MassUploadForm

        //public Guid? MediaFileId { get; set; }
        //[ForeignKey(nameof(MediaFileId))]
        //public MediaFile MediaFile { get; set; }

        /// <summary>
        /// Use MediaFile entity in the future when integrated with AWS S3 Bucket
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Category ForeignKey
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        /// <summary>
        /// Material type ForeignKey
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public Materials.Types.Type Type { get; set; }

        /// <summary>
        /// OEM Item Code
        /// </summary>
        [Required]
        public string ItemCode { get; set; }

        /// <summary>
        /// OEM Color Code
        /// </summary>
        [Required]
        public string ColorCode { get; set; }

        /// <summary>
        /// Color ForeignKey
        /// </summary>
        [Required]
        public int ColorId { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }

        /// <summary>
        /// Pantone # (TCX Code)
        /// </summary>
        public string? Pantone { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Weight { get; set; }

        /// <summary>
        /// Weight Unit ForeignKey
        /// </summary>
        [Required]
        public int WeightUnitId { get; set; }
        [ForeignKey(nameof(WeightUnitId))]
        public WeightUnit WeightUnit { get; set; }

        /// <summary>
        /// Cuttable Width
        /// </summary>
        public string? CuttableWidth { get; set; }

        #endregion

        #endregion

        #region Inventory

        /// <summary>
        /// Expected Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? IncomingCount { get; set; }

        /// <summary>
        /// Reserved Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ReservedCount { get; set; }

        /// <summary>
        /// Available Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? AvailableCount { get; set; }

        /// <summary>
        /// Used Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? UsedCount { get; set; }

        /// <summary>
        /// Minimum Stock Level
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? MinimumStockLevel { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double OnHandCount { get; set; }

        #region MassUploadForm

        /// <summary>
        /// Actual Count
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double TotalCount { get; set; }



        /// <summary>
        /// Unit of Measurement ForeignKey
        /// </summary>
        [Required]
        public int UnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(UnitOfMeasurementId))]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        #endregion

        #endregion

        #region Roll And Location

        /// <summary>
        /// Rolls and Locations
        /// </summary>
        public List<Roll> RollsAndLocations { get; set; } = new();

        /// <summary>
        /// Add Roll and Location
        /// </summary>
        /// <param name="rollAndLocation"></param>
        public void AddRollAndLocation(Roll rollAndLocation)
        {
            RollsAndLocations.Add(rollAndLocation);
        }

        /// <summary>
        /// Add Rolls and Locations
        /// </summary>
        /// <param name="rollAndLocations"></param>
        public void AddRollsAndLocations(IEnumerable<Roll> rollAndLocations)
        {
            RollsAndLocations.AddRange(rollAndLocations);
        }

        #endregion

        #region Composition and Construction

        /// <summary>
        /// Composition and Construction ForeignKey
        /// </summary>
        [Required]
        public Guid CompositionAndConstructionId { get; set; }
        [ForeignKey(nameof(CompositionAndConstructionId))]
        public CompositionAndConstruction CompositionAndConstruction { get; set; }

        #endregion

        #region Miscellanous

        /// <summary>
        /// Care Instruction type ForeignKey
        /// </summary>
        [Required]
        public int CareInstructionTypeId { get; set; }
        [ForeignKey(nameof(CareInstructionTypeId))]
        public CareInstructionType CareInstructionType { get; set; }

        #endregion

        #region Supplier

        /// <summary>
        /// Supplier type ForeignKey
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        #endregion

        #region Purchase Detail

        /// <summary>
        /// Purchase Detail type ForeignKey
        /// </summary>
        [Required]
        public Guid PurchaseDetailId { get; set; }
        [ForeignKey(nameof(PurchaseDetailId))]
        public PurchaseDetail PurchaseDetail { get; set; }

        #endregion

        /// <summary>
        /// Update the Total count of material.
        /// </summary>
        /// <param name="amount"></param>
        private void UpdateActualCount(double amount)
        {
            this.TotalCount = amount;
        }


        /// <summary>
        /// Consume material.
        /// </summary>
        /// <param name="amountToDeduct"></param>
        private void UseMaterial(double amountToDeduct)
        {
            if (amountToDeduct <= 0) throw new UserFriendlyException($"Amount to deduct must be greater than 0.");

            this.UsedCount += (this.TotalCount - amountToDeduct);
        }

        /// <summary>
        /// Calculate the reserved count.
        /// </summary>
        /// <param name="reserveAmount"></param>
        /// <exception cref="UserFriendlyException"></exception>
        public void ReserveMaterial(double reserveAmount)
        {
            if (reserveAmount <= 0) throw new UserFriendlyException($"Reservation amount must be greater than 0.");

            this.ReservedCount += reserveAmount;

            CalculateAvailableCount();

            if (AvailableCount == null || AvailableCount < 0) throw new UserFriendlyException($"Material {this.Name}, not enough stock. Available Count: {AvailableCount += reserveAmount}");
        }

        /// <summary>
        /// Remove reserved Material.
        /// </summary>
        /// <param name="reserveAmount"></param>
        /// <exception cref="UserFriendlyException"></exception>
        public void DeleteReservedMaterial(double reserveAmount)
        {
            if (reserveAmount <= 0) throw new UserFriendlyException($"Reservation amount must be greater than 0.");

            this.ReservedCount -= reserveAmount;

            CalculateAvailableCount();

            if (AvailableCount == null || AvailableCount < 0) throw new UserFriendlyException($"Not enough stock. Available Count: {AvailableCount -= reserveAmount}");
        }

        /// <summary>
        /// Calculate the Available count.
        /// </summary>
        public void CalculateAvailableCount()
        {
            // Check if ReservedCount is null assign 0.
            ReservedCount ??= 0;

            AvailableCount = TotalCount - ReservedCount;
        }

        /// <summary>
        /// Check Minimum Stock Level
        /// </summary>
        /// <returns>Return true if Available Count is greater than Minimum Stock Level or isExcess is true, else false.</returns>
        public bool CheckMinimumStockLevel(bool isExcess)
        {
            bool result = default;

            if (isExcess || !MinimumStockLevel.HasValue || AvailableCount >= MinimumStockLevel) result = true;

            return result;
        }

        /// <summary>
        /// Generate Material Name
        /// </summary>
        /// <param name="supplierShortCode"></param>
        /// <param name="isExcess"></param>
        /// <param name="typeShortCode"></param>
        /// <param name="suffixNumber"></param>
        /// <exception cref="UserFriendlyException"></exception>
        public void GenerateName(string supplierShortCode, bool isExcess, string typeShortCode, int suffixNumber)
        {
            var excessOrNew = isExcess ? "E" : "N";

            if (string.IsNullOrWhiteSpace(supplierShortCode)) throw new UserFriendlyException("Supplier ShortCode should not be null.");

            if (string.IsNullOrWhiteSpace(typeShortCode)) throw new UserFriendlyException("Type ShortCode should not be null.");

            this.ItemCode = this.ItemCode.Trim();

            this.ColorCode = this.ColorCode.Trim();

            this.Name = $@"{supplierShortCode}-{ItemCode}-{ColorCode}-{excessOrNew}-{typeShortCode}-{suffixNumber}".ToUpper();
        }

        public void CreateAdjustment(Adjustment adjustment, double amount, string action)
        {
            // Get the actual count from Material Entity before the adjustment
            adjustment.From = TotalCount;

            // Get the user To be refactor once User Module is integrated
            adjustment.User = "Admin";

            // Adjustment Procedure Start
            UpdateActualCount(amount);

            if (action == "Decrement")
                UseMaterial(amount);

            CalculateAvailableCount();
        }

        public void CalculateOnHandCount(Material material)
        {
            material.OnHandCount = (double)(material.TotalCount - material.IncomingCount);
        }

    }
}