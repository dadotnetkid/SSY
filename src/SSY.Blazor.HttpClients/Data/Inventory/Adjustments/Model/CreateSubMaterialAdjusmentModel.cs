using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class CreateSubMaterialAdjustmentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [Required]
        [JsonPropertyName("subMaterialId")]
        public Guid SubMaterialId { get; set; }

        [Required]
        [JsonPropertyName("actionId")]
        public int ActionId { get; set; }

        [Required]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [Required]
        [JsonPropertyName("to")]
        public double To { get; set; }

        [JsonPropertyName("from")]
        public double From { get; set; }

    }
}

