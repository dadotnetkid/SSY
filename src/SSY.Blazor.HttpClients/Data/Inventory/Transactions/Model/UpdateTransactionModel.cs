using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Transactions.Model
{
    public class UpdateTransactionModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }
        [JsonPropertyName("orderType")]
        public string OrderType { get; set; }
        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }
        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }
    }
}

