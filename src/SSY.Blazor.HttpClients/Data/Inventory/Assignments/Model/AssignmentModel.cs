using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Assignments.Model
{
    public class AssignmentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("consumption")]
        public double Consumption { get; set; }
        [JsonPropertyName("productType")]
        public string ProductType { get; set; }
        [JsonPropertyName("collection")]
        public string Collection { get; set; }
        [JsonPropertyName("influencer")]
        public string Influencer { get; set; }
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }
    }
}

