using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{
    public class PanelData
    {
        [JsonPropertyName("result")]
        public PanelResults Result { get; set; }
    }
    public class PanelResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<PanelModel> Items { get; set; }
    }
    public class PanelResult
    {
        [JsonPropertyName("result")]
        public PanelModel Result { get; set; }

    }


    public class PanelModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("typeLabel")]
        public string TypeLabel { get; set; }

        [JsonPropertyName("typeValue")]
        public string TypeValue { get; set; }

        [JsonPropertyName("panelId")]
        public int PanelId { get; set; }

        [JsonPropertyName("panelLabel")]
        public string PanelLabel { get; set; }

        [JsonPropertyName("panelValue")]
        public string PanelValue { get; set; }

    }
}
