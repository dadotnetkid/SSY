using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class GetAllAdjustmentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("adjustmentId")]
        public Guid AdjustmentId { get; set; }

        [JsonPropertyName("subMaterialId")]
        public Guid SubMaterialId { get; set; }

        [JsonPropertyName("adjustmentActionId")]
        public int AdjustmentActionId { get; set; }

        [JsonPropertyName("adjustmentTypeValue")]
        public string AdjustmentTypeValue { get; set; }

        [JsonPropertyName("adjustmentDate")]
        public DateTime AdjustmentDate { get; set; }

        [JsonPropertyName("adjustmentRemarks")]
        public string? AdjustmentRemarks { get; set; }

        [JsonPropertyName("adjustmentFrom")]
        public double AdjustmentFrom { get; set; }

        [JsonPropertyName("adjustmentTo")]
        public double AdjustmentTo { get; set; }

        [JsonPropertyName("adjustmentUser")]
        public string AdjustmentUser { get; set; }
    }


}


