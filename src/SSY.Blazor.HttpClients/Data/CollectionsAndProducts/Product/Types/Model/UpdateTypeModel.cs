using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Types.Model
{
    public class UpdateProductTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int? OrderNumber { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("averageConsumption")]
        public double AverageConsumption { get; set; }

        [JsonPropertyName("salesPercentage")]
        public double? SalesPercentage { get; set; }

        [JsonPropertyName("subSalesPercentage")]
        public double? SubSalesPercentage { get; set; }

        [JsonPropertyName("productCategoryId")]
        public int? ProductCategoryId { get; set; }

        [JsonPropertyName("freeShippingFedExPrice")]
        public double? FreeShippingFedExPrice { get; set; }

        [JsonPropertyName("freeShippingDHLPrice")]
        public double? FreeShippingDHLPrice { get; set; }

        [JsonPropertyName("tenUSDPrice")]
        public double? TenUSDPrice { get; set; }

        [JsonPropertyName("fifteenUSDPrice")]
        public double? FiftenUSDPrice { get; set; }

        [JsonPropertyName("twentyUSDPrice")]
        public double? TwentyUSDPrice { get; set; }

    }
}

