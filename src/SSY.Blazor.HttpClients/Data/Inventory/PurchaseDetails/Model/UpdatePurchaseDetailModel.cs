using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model
{
    public class UpdatePurchaseDetailModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        #region Price Per Unit

        /// <summary>
        /// Price
        /// </summary>

        [JsonPropertyName("price")]
        public double? Price { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        [JsonPropertyName("count")]
        public double? Count { get; set; }

        /// <summary>
        /// Price Per Unit Currency ForeignKey
        /// </summary>
        [JsonPropertyName("currencyId")]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Price Per Unit Unit of Measurement ForeignKey
        /// </summary>
        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        /// <summary>
        /// Upchargetype ForeignKey
        /// </summary>
        [JsonPropertyName("upchargeTypeId")]
        public int? UpchargeTypeId { get; set; }

        /// <summary>
        /// Pricing type ForeignKey
        /// </summary>
        [JsonPropertyName("pricingTypeId")]
        public int? PricingTypeId { get; set; }

        #endregion

        #region Below Minimum Order Quantity

        /// <summary>
        /// Upcharge
        /// </summary>
        [JsonPropertyName("upcharge")]
        public double? Upcharge { get; set; }

        /// <summary>
        /// Upcharge Percentage
        /// </summary>
        public double? UpchargePercentage { get; set; }

        /// <summary>
        /// Upcharge Price
        /// </summary>
        public double? UpchargePrice { get; set; }

        /// <summary>
        /// Below Minimum Order Quantity Count
        /// </summary>
        [JsonPropertyName("belowMinimumOrderQuantityCount")]
        public double? BelowMinimumOrderQuantityCount { get; set; }

        /// <summary>
        /// Below Minimum Order Quantity Currency ForeignKey
        /// </summary>
        [JsonPropertyName("belowMinimumOrderQuantityCurrencyId")]
        public int? BelowMinimumOrderQuantityCurrencyId { get; set; }

        /// <summary>
        /// Below Minimum Order Quantity Unit of Measurement ForeignKey
        /// </summary>
        [JsonPropertyName("belowMinmumOrderQuantityUnitOfMeasurementId")]
        public int? BelowMinmumOrderQuantityUnitOfMeasurementId { get; set; }
        #endregion

        #region General Information

        /// <summary>
        /// General Information Minimum Order Quantity
        /// </summary>
        [JsonPropertyName("generalInformationMinimumOrderQuantity")]
        public double? GeneralInformationMinimumOrderQuantity { get; set; }

        /// <summary>
        /// General Information Minimum Color Quantity
        /// </summary>
        [JsonPropertyName("generalInformationMinimumColorQuantity")]
        public double? GeneralInformationMinimumColorQuantity { get; set; }

        /// <summary>
        /// General Information Unit of Measurement ForeignKey
        /// </summary>
        [JsonPropertyName("generalInformationUnitOfMeasurementId")]
        public int? GeneralInformationUnitOfMeasurementId { get; set; }

        /// <summary>
        /// Lead Time
        /// </summary>
        [JsonPropertyName("leadTime")]
        public string? LeadTime { get; set; }

        /// <summary>
        /// Shipping Time By Air
        /// </summary>
        [JsonPropertyName("shippingTimeByAir")]
        public string? ShippingTimeByAir { get; set; }

        /// <summary>
        /// Shipping Time By Sea
        /// </summary>
        [JsonPropertyName("shippingTimeBySea")]
        public string? ShippingTimeBySea { get; set; }
        #endregion

        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }
    }
}
