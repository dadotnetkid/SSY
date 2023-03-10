using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model
{
    public class PurchaseDetailModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("price")]
        public double? Price { get; set; }

        [JsonPropertyName("count")]
        public double? Count { get; set; }

        [JsonPropertyName("currencyId")]
        public int? CurrencyId { get; set; }

        [JsonPropertyName("currencyLabel")]
        public string? CurrencyLabel { get; set; }

        [JsonPropertyName("currencyValue")]
        public string? CurrencyValue { get; set; }

        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        [JsonPropertyName("unitOfMeasurementLabel")]
        public string? UnitOfMeasurementLabel { get; set; }

        [JsonPropertyName("unitOfMeasurementValue")]
        public string? UnitOfMeasurementValue { get; set; }

        [JsonPropertyName("upchargeTypeId")]
        public int? UpchargeTypeId { get; set; }

        [JsonPropertyName("upchargeLabel")]
        public string? UpchargeLabel { get; set; }

        [JsonPropertyName("upchargeValue")]
        public string? UpchargeValue { get; set; }

        [JsonPropertyName("upcharge")]
        public double? Upcharge { get; set; }

        [JsonPropertyName("upchargePercentage")]
        public double? UpchargePercentage { get; set; }

        [JsonPropertyName("isUpchargePercentage")]
        public bool IsUpchargePercentage { get; set; } = false;

        [JsonPropertyName("isUpchargePrice")]
        public bool IsUpchargePrice { get; set; }

        [JsonPropertyName("upchargePrice")]
        public double? UpchargePrice { get; set; }

        [JsonPropertyName("belowMinimumOrderQuantityCount")]
        public double? BelowMinimumOrderQuantityCount { get; set; }

        [JsonPropertyName("belowMinimumOrderQuantityCurrencyId")]
        public int? BelowMinimumOrderQuantityCurrencyId { get; set; }

        [JsonPropertyName("belowMinimumOrderQuantityCurrencyLabel")]
        public string? BelowMinimumOrderQuantityCurrencyLabel { get; set; }

        [JsonPropertyName("belowMinimumOrderQuantityCurrencyValue")]
        public string? BelowMinimumOrderQuantityCurrencyValue { get; set; }

        [JsonPropertyName("belowMinmumOrderQuantityUnitOfMeasurementId")]
        public int? BelowMinmumOrderQuantityUnitOfMeasurementId { get; set; }

        [JsonPropertyName("belowMinmumOrderQuantityUnitOfMeasurementLabel")]
        public string? BelowMinmumOrderQuantityUnitOfMeasurementLabel { get; set; }

        [JsonPropertyName("belowMinmumOrderQuantityUnitOfMeasurementValue")]
        public string? BelowMinmumOrderQuantityUnitOfMeasurementValue { get; set; }

        [JsonPropertyName("generalInformationMinimumOrderQuantity")]
        public double? GeneralInformationMinimumOrderQuantity { get; set; }

        [JsonPropertyName("generalInformationMinimumColorQuantity")]
        public double? GeneralInformationMinimumColorQuantity { get; set; }

        [JsonPropertyName("generalInformationUnitOfMeasurementId")]
        public int? GeneralInformationUnitOfMeasurementId { get; set; }

        [JsonPropertyName("generalInformationUnitOfMeasurementLabel")]
        public string? GeneralInformationUnitOfMeasurementLabel { get; set; }

        [JsonPropertyName("generalInformationUnitOfMeasurementValue")]
        public string? GeneralInformationUnitOfMeasurementValue { get; set; }

        [JsonPropertyName("leadTime")]
        public string? LeadTime { get; set; }

        [JsonPropertyName("shippingTimeByAir")]
        public string? ShippingTimeByAir { get; set; }

        [JsonPropertyName("shippingTimeBySea")]
        public string? ShippingTimeBySea { get; set; }

        [JsonPropertyName("pricingTypeId")]
        [Required(ErrorMessage = "This field is required.")]
        public int? PricingTypeId { get; set; }

        [JsonPropertyName("pricingTypeLable")]
        public string? PricingTypeLabel { get; set; }

        [JsonPropertyName("pricingTypeValue")]
        public string? PricingTypeValue { get; set; }

        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }
    }
}
