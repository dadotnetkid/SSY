using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollAdjustments.Model
{
    public partial class RollAdjustmentModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("adjusmentId")]
        public Guid AdjusmentId { get; set; }
        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }
        [JsonPropertyName("rollId")]
        public Guid RollId { get; set; }
        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }
        [JsonPropertyName("adjustmentId")]
        public Guid AdjustmentId { get; set; }

        [JsonPropertyName("adjustmentActionId")]
        public int ActionId { get; set; }
        [JsonPropertyName("adjustmentTypeValue")]
        public string Action { get; set; }
        [JsonPropertyName("adjustmentDate")]
        public DateTime Date { get; set; }
        [JsonPropertyName("adjustmentTo")]
        public double To { get; set; }
        [JsonPropertyName("adjustmentFrom")]
        public double From { get; set; }
        [JsonPropertyName("adjustmentRemarks")]
        public string Remarks { get; set; }
        [JsonPropertyName("adjustmentUser")]
        public string User { get; set; }
    }
  
}

