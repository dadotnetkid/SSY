using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollAdjustments.Model
{
    public class CreateRollAdjustmentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("adjusmentId")]
        public Guid AdjusmentId { get; set; }
        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }
        [JsonPropertyName("rollId")]
        public Guid RollId { get; set; }
        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }
    }
}

