using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model
{
    public class UpdateCompositionAndConstructionModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("construction")]
        public string? Construction { get; set; }

        [JsonPropertyName("gauge")]
        public string? Gauge { get; set; }

        [Required]
        [JsonPropertyName("recycledId")]
        public int RecycledId { get; set; }

        [Required]
        [JsonPropertyName("excessId")]
        public int ExcessId { get; set; }

        [Required]
        [JsonPropertyName("preparedForPrintId")]
        public int PreparedForPrintId { get; set; }

        [Required]
        [JsonPropertyName("compressionId")]
        public int? CompressionId { get; set; }

        [JsonPropertyName("fabricStretchId")]
        public int? FabricStretchId { get; set; }

        [JsonPropertyName("creaseId")]
        public int? CreaseId { get; set; }

        [JsonPropertyName("printRepeatId")]
        public int? PrintRepeatId { get; set; }

        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [Required]
        [JsonPropertyName("handFeelIds")]
        public string HandFeelIds { get { return JsonSerializer.Serialize(HandFeelIdList); } }

        public List<int> HandFeelIdList { get; set; } = new();
    }
}
