using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories.Model
{
    public class UpdatePurchasingHistoryModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

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

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("orderBy")]
        public string OrderBy { get; set; }
    }
}

