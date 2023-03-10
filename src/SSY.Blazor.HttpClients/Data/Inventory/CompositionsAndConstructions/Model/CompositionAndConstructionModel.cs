using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model
{
    public class CompositionAndConstructionModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("content")]
        [Required(ErrorMessage = "This field is required.")]
        public string Content { get; set; }

        [JsonPropertyName("construction")]
        public string? Construction { get; set; }

        [JsonPropertyName("gauge")]
        public string? Gauge { get; set; }

        [JsonPropertyName("recycledId")]
        [Required(ErrorMessage = "This field is required.")]
        public int? RecycledId { get; set; }

        [JsonPropertyName("recycledLabel")]
        public string RecycledLabel { get; set; }

        [JsonPropertyName("recycledValue")]
        public string RecycledValue { get; set; }

        [JsonPropertyName("excessId")]
        [Required(ErrorMessage = "This field is required.")]
        public int? ExcessId { get; set; }

        [JsonPropertyName("excessLabel")]
        public string ExcessLabel { get; set; }

        [JsonPropertyName("excessValue")]
        public string ExcessValue { get; set; }

        [JsonPropertyName("preparedForPrintId")]
        [Required(ErrorMessage = "This field is required.")]
        public int? PreparedForPrintId { get; set; } = 1002;

        [JsonPropertyName("preparedForPrintLabel")]
        public string PreparedForPrintLabel { get; set; }

        [JsonPropertyName("preparedForPrintValue")]
        public string PreparedForPrintValue { get; set; }

        [JsonPropertyName("compressionId")]
        public int? CompressionId { get; set; }

        [JsonPropertyName("compressionLabel")]
        public string CompressionLabel { get; set; }

        [JsonPropertyName("compressionValue")]
        public string CompressionValue { get; set; }

        [JsonPropertyName("fabricStretchId")]
        public int? FabricStretchId { get; set; }

        [JsonPropertyName("fabricStretchLabel")]
        public string FabricStretchLabel { get; set; }

        [JsonPropertyName("fabricStretchValue")]
        public string FabricStretchValue { get; set; }

        [JsonPropertyName("creaseId")]
        public int? CreaseId { get; set; }

        [JsonPropertyName("creaseLabel")]
        public string CreaseLabel { get; set; }

        [JsonPropertyName("creaseValue")]
        public string CreaseValue { get; set; }

        [JsonPropertyName("printRepeatId")]
        // [Required(ErrorMessage = "This field is required.")]
        public int? PrintRepeatId { get; set; }

        [JsonPropertyName("printRepeatLabel")]
        public string PrintRepeatLabel { get; set; }

        [JsonPropertyName("printRepeatValue")]
        public string PrintRepeatValue { get; set; }

        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [JsonPropertyName("handfeels")]
        [Required(ErrorMessage = "This field is required.")]
        public List<HandFeelModel> HandFeels { get; set; } = new();

        public void AddHandFeels(HandFeelModel assignment)
        {
            HandFeels.Add(assignment);
        }

        [JsonPropertyName("handFeelIds")]
        public string? HandFeelIds { get; set; }

        public List<int> HandFeelIdList { get; set; } = new();
    }
}
