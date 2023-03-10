using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{

    public class DeleteModel
    {
        // [JsonPropertyName("result")]
        // public int Result { get; set; }

        // [JsonPropertyName("targetUrl")]
        // public int TenantId { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        //      [JsonPropertyName("error")]
        //     public string Label { get; set; }
    }


}


