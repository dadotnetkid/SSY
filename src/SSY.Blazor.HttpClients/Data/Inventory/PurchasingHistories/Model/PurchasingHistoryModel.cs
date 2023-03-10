using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories.Model
{
    public class PurchasingHistoryModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }


        [JsonPropertyName("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("orderQuantity")]
        public double OrderQuantity { get; set; }

        [JsonPropertyName("unitOfMeasurementId")]
        public int UnitOfMeasurementId { get; set; }

        [JsonPropertyName("unitOfMeasurementLabel")]
        public string UnitOfMeasurementLabel { get; set; }

        [JsonPropertyName("unitOfMeasurementValue")]
        public string UnitOfMeasurementValue { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("orderBy")]
        public string OrderBy { get; set; }
    }
}

