using System;
using System.Collections.Generic;
using SSY.Inventory.Categories;
using SSY.Inventory.Colors;
using SSY.Inventory.UnitOfMeasurements;
using SSY.Inventory.WeightUnits;

namespace SSY.Inventory
{
    /// <summary>
    /// Sub Material - Trims And Accessories / Packaging / Others
    /// </summary>
    [Index(propertyNames: new[] { nameof(Name) }, IsUnique = true)]
    [Table("AppSubMaterials")]
    public class SubMaterial : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }


        #region Accountability

        public Guid? AccountabilityId { get; set; }
        [ForeignKey(nameof(AccountabilityId))]
        public Accountability Accountability { get; set; }

        #endregion


        #region Overview

        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required(ErrorMessage = "This Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Material Type ID field is required")]
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public Materials.Types.Type Type { get; set; }

        [Required(ErrorMessage = "This Color ID field is required")]
        public int ColorId { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? Weight { get; set; }

        [Required(ErrorMessage = "This Weight Unit ID field is required")]
        public int WeightUnitId { get; set; }
        [ForeignKey(nameof(WeightUnitId))]
        public WeightUnit WeightUnit { get; set; }

        #endregion


        #region Inventory

        [Required(ErrorMessage = "This Total Count field is required")]
        [Column(TypeName = "decimal(18,2)")]
        public double TotalCount { get; set; }

        [Required(ErrorMessage = "This Unit of Measurement ID field is required")]
        public int UnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(UnitOfMeasurementId))]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? MinimumStockLevel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? IncomingCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? OnHandCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? ReservedCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? AvailableCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double? UsedCount { get; set; }

        #endregion




        #region Location

        [Required(ErrorMessage = "This Location field is required")]
        public Guid LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }

        #endregion



        #region Supplier

        [Required]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        #endregion


        #region Purchase Detail
        [Required]
        public Guid PurchaseDetailId { get; set; }
        [ForeignKey(nameof(PurchaseDetailId))]
        public PurchaseDetail PurchaseDetail { get; set; }

        #endregion

        /// <summary>
        /// Purchase Detail Number
        /// </summary>
        public string PONumber { get; set; }

        /// <summary>
        /// Amount of shipped roll
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ShippedCount { get; set; }

        /// <summary>
        /// Amount of received roll
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ReceivedCount { get; set; }

        public virtual List<ReserveCollectionSubMaterialKey> SubMaterialReservations { get; set; }


        // Default constructor use by Entity Framework Core don't remove.
        public SubMaterial()
        {
        }

        public SubMaterial(double totalCount, double? minimumStockLevel, double? incomingCount, double reservedCount,
                        double? availableCount, double? usedCount, string poNumber, double? shippedCount,
                        double? onHandCount, double? receivedCount)
        {
            TotalCount = totalCount;
            MinimumStockLevel = minimumStockLevel;
            IncomingCount = incomingCount;
            ReservedCount = reservedCount;
            AvailableCount = availableCount;
            UsedCount = usedCount;
            PONumber = poNumber;
            ShippedCount = shippedCount;
            ReceivedCount = receivedCount;
            OnHandCount = onHandCount;
        }


        /// <summary>
        /// Update the Total count of material.
        /// </summary>
        /// <param name="amount"></param>
        private void UpdateTotalCount(double amount)
        {
            TotalCount = amount;
        }

        /// <summary>
        /// Consume material.
        /// </summary>
        /// <param name="amountToDeduct"></param>
        private void UseMaterial(double amountToDeduct)
        {
            if (amountToDeduct <= 0) throw new UserFriendlyException($"Amount to deduct must be greater than 0.");

            UsedCount += TotalCount - amountToDeduct;
        }

        /// <summary>
        /// Calculate the reserved count.
        /// </summary>
        /// <param name="reserveAmount"></param>
        /// <exception cref="UserFriendlyException"></exception>
        public void ReserveMaterial(double reserveAmount)
        {
            if (reserveAmount <= 0) throw new UserFriendlyException($"Reservation amount must be greater than 0.");

            ReservedCount += reserveAmount;

            CalculateAvailableCount();

            if (AvailableCount == null || AvailableCount < 0) throw new UserFriendlyException($"Not enough stock. Available Count: {AvailableCount += reserveAmount}");
        }

        /// <summary>
        /// Remove reserved Material.
        /// </summary>
        /// <param name="reserveAmount"></param>
        /// <exception cref="UserFriendlyException"></exception>
        public void DeleteReservedMaterial(double reserveAmount)
        {
            if (reserveAmount <= 0) throw new UserFriendlyException($"Reservation amount must be greater than 0.");

            ReservedCount -= reserveAmount;

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
        /// Generate Material Name
        /// </summary>
        /// <param name="supplierShortCode"></param>
        /// <param name="isExcess"></param>
        /// <param name="typeShortCode"></param>
        /// <param name="suffixNumber"></param>
        /// <exception cref="UserFriendlyException"></exception>
        //public void GenerateName(string supplierShortCode, bool isExcess, string typeShortCode, int suffixNumber)
        //{
        //    var excessOrNew = isExcess ? "E" : "N";

        //    if (string.IsNullOrWhiteSpace(supplierShortCode)) throw new UserFriendlyException("Supplier ShortCode should not be null.");

        //    if (string.IsNullOrWhiteSpace(typeShortCode)) throw new UserFriendlyException("Type ShortCode should not be null.");

        //    this.Name = $@"{supplierShortCode}-{ItemCode}-{ColorCode}-{excessOrNew}-{typeShortCode}-{suffixNumber}".ToUpper();
        //}

        public void CreateAdjustment(Adjustment adjustment, double amount, string action)
        {
            // Get the actual count from Material Entity before the adjustment
            adjustment.From = TotalCount;

            // Get the user To be refactor once User Module is integrated
            adjustment.User = "Admin";

            // Adjustment Procedure Start
            UpdateTotalCount(amount);

            if (action == "Decrement")
                UseMaterial(amount);

            CalculateAvailableCount();
        }

        public void CalculateOnHandCount(SubMaterial subMaterial)
        {
            subMaterial.OnHandCount = (double)(subMaterial.TotalCount - subMaterial.IncomingCount);
        }

    }
}
