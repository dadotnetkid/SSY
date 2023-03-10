using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{
    public class HandFeelData
    {
        [JsonPropertyName("result")]
        public HandFeelResults Result { get; set; }
    }
    public class HandFeelResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<HandFeelModel> Items { get; set; }
    }
    public class HandFeelResult
    {
        [JsonPropertyName("result")]
        public HandFeelModel Result { get; set; }

    }


    public class HandFeelModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

    }
}
