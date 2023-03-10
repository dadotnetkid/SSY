

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SSY.Inventory.Currencies;
using SSY.Inventory.UnitOfMeasurements;

namespace SSY.Inventory
{
    /// <summary>
    /// Purchase Detail
    /// </summary>
    [Table("AppPurchaseDetails")]
    public class PurchaseDetail : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        #region Price Per Unit

        /// <summary>
        /// Price
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? Price { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? Count { get; set; }

        /// <summary>
        /// Price Per Unit Currency ForeignKey
        /// </summary>
        public int? CurrencyId { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; }

        /// <summary>
        /// Price Per Unit Unit of Measurement ForeignKey
        /// </summary>
        public int? UnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(UnitOfMeasurementId))]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        #endregion

        #region Below Minimum Order Quantity

        /// <summary>
        /// Upcharge
        /// </summary>
        ///
        [Column(TypeName = "decimal(18,2)")]
        public double? Upcharge { get; set; }

        /// <summary>
        /// Upcharge Type
        /// </summary>
        public int? UpchargeTypeId { get; set; }
        [ForeignKey(nameof(UpchargeTypeId))]
        public UpchargeType UpchargeType { get; set; }

        /// <summary>
        /// Upcharge Type
        /// </summary>
        public double? UpchargePercentage { get; set; }

        /// <summary>
        /// Upcharge Price
        /// </summary>
        public double? UpchargePrice { get; set; }


        /// <summary>
        /// Below Minimum Order Quantity Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? BelowMinimumOrderQuantityCount { get; set; }

        /// <summary>
        /// Below Minimum Order Quantity Currency ForeignKey
        /// </summary>
        public int? BelowMinimumOrderQuantityCurrencyId { get; set; }
        [ForeignKey(nameof(BelowMinimumOrderQuantityCurrencyId))]
        public Currency BelowMinimumOrderQuantityCurrency { get; set; }

        /// <summary>
        /// Below Minimum Order Quantity Unit of Measurement ForeignKey
        /// </summary>
        public int? BelowMinmumOrderQuantityUnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(BelowMinmumOrderQuantityUnitOfMeasurementId))]
        public UnitOfMeasurement BelowMinmumOrderQuantityUnitOfMeasurement { get; set; }
        #endregion

        #region General Information

        /// <summary>
        /// General Information Minimum Order Quantity
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? GeneralInformationMinimumOrderQuantity { get; set; }

        /// <summary>
        /// General Information Minimum Color Quantity
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? GeneralInformationMinimumColorQuantity { get; set; }

        /// <summary>
        /// General Information Unit of Measurement ForeignKey
        /// </summary>
        public int? GeneralInformationUnitOfMeasurementId { get; set; }
        [ForeignKey(nameof(GeneralInformationUnitOfMeasurementId))]
        public UnitOfMeasurement GeneralInformationUnitOfMeasurement { get; set; }

        /// <summary>
        /// Lead Time
        /// </summary>
        public string LeadTime { get; set; }

        /// <summary>
        /// Shipping Time By Air
        /// </summary>
        public string ShippingTimeByAir { get; set; }

        /// <summary>
        /// Shipping Time By Sea
        /// </summary>
        public string ShippingTimeBySea { get; set; }

        /// <summary>
        /// Pricing Type
        /// </summary>
        public int? PricingTypeId { get; set; }
        [ForeignKey(nameof(PricingTypeId))]
        public PricingType PricingType { get; set; }

        public Guid? RequestId { get; set; }

        #endregion

        // Default constructor use by Entity Framework Core don't remove.
        public PurchaseDetail()
        {
        }
    }
}
