using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Types.Model
{
    public class CreateTypeModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int? OrderNumber { get; set; }

        [JsonPropertyName("categoryId")]
        public int CatergoryId { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("salesPercentage")]
        public double? SalesPercentage { get; set; }

        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        [JsonPropertyName("panelIds")]
        public int? PanelIds { get; set; }

        [JsonPropertyName("PanelIdList")]
        public List<int> PanelIdList { get; set; } = new();

        [JsonPropertyName("panels")]
        public List<PanelModel> Panels { get; set; } = new();

    }
}
