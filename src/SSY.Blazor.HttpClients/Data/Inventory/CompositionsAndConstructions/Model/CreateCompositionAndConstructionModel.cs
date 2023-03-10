using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model
{
    public class CreateCompositionAndConstructionModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("construction")]
        public string? Construction { get; set; }

        [JsonPropertyName("gauge")]
        public string? Gauge { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("recycledId")]
        public int RecycledId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("excessId")]
        public int ExcessId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("preparedForPrintId")]
        public int PreparedForPrintId { get; set; }


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

        [JsonPropertyName("handFeelIdList")]
        public List<int> HandFeelIdList { get; set; } = new();
    }
}
