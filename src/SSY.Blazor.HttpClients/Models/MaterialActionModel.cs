using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{


    public class MaterialActionData
    {
        [JsonPropertyName("result")]
        public MaterialActionResults Result { get; set; }

    }
    public class MaterialActionResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<MaterialActionModel> Items { get; set; }
    }
    public class MaterialActionResult
    {
        [JsonPropertyName("result")]
        public MaterialActionModel Result { get; set; }

    }

    public class MaterialActionModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("orederNumber")]
        public int OrderNumber { get; set; }

    }


}


