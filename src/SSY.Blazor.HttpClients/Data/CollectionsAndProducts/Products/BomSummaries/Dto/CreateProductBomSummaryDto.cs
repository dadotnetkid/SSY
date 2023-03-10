using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto
{
    public class CreateProductBomSummaryDto
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("partNumber")]
        public int PartNumber { get; set; }

        [JsonPropertyName("partName")]
        public string PartName { get; set; }

        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("consumption")]
        public double Consumption { get; set; }

        [JsonPropertyName("unitOfMeasurement")]
        public string UnitOfMeasurement { get; set; }

        [JsonPropertyName("cuttableWidth")]
        public string CuttableWidth { get; set; }

        [JsonPropertyName("contentDescription")]
        public string ContentDescription { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("supplier")]
        public string Supplier { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}

