using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class UpdateAdjustmentModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("actionId")]
        public int ActionId { get; set; }

        [Required]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [Required]
        [JsonPropertyName("from")]
        public double From { get; set; } = 1;

        [Required]
        [JsonPropertyName("to")]
        public double To { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("materialAction")]
        public MaterialActionListModel MaterialActionListModel { get; set; } = new();

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}

