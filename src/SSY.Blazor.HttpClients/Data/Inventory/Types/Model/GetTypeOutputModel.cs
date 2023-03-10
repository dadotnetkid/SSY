using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Types.Model
{
    public class GetTypeOutputModel
    {
        [JsonPropertyName("result")]
        public TypeModel Result { get; set; }
    }
}

